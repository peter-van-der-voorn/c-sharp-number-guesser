using System;

namespace number_guesser
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintAppDetails();
            string name = GreetUser();
            RunGame(name);
        }

        static string GreetUser() {
            // ask for name
            PrintColouredMsg(ConsoleColor.DarkGreen, "Hello, please enter your name: ");

            // take name as input
            string name = Console.ReadLine();

            // print welcome message
            string msg = "Welcome, " + name + ", let's play!";
            Console.WriteLine();
            PrintColouredMsg(ConsoleColor.DarkCyan, msg);
            Console.WriteLine();

            return name;
        }

        static void PrintAppDetails() {
            string version = "1.0.0";
            string appName = "Number Guesser";
            string author = "Peter van der Voorn";
            string msg = appName + " - v" + version + " by " + author;

            PrintColouredMsg(ConsoleColor.DarkYellow, msg);
            Console.WriteLine();
        }

        static void PrintColouredMsg(ConsoleColor colour, string message) {
            Console.ForegroundColor = colour;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        static void RunGame(string name)
        {
            while (true)
            {
                Random random = new Random();
                int secretNum = random.Next(1, 10);

                bool guessedCorrectly = false;

                while (!guessedCorrectly)
                {
                    // prompt user to enter a guess
                    PrintColouredMsg(ConsoleColor.Cyan, "Enter an integer between 1 & 10 (inclusive):");
                    string guess = Console.ReadLine();

                    // check if guess is an int

                    if (Int32.TryParse(guess, out int result))
                    {
                        if (result == secretNum)
                        {
                            string successMsg = "Well done, " + name + ", you got it!";
                            PrintColouredMsg(ConsoleColor.Green, successMsg);
                            guessedCorrectly = true;

                        }
                        else
                        {
                            PrintColouredMsg(ConsoleColor.Red, "incorrect, try again");
                        }
                    }
                    else
                    {
                        PrintColouredMsg(ConsoleColor.Red, "Invalid input");
                    }
                }

                
                if (PlayAgain())
                {
                    continue;
                }
                else
                {
                    return;
                }

            }
        }

        static bool PlayAgain()
        {
            // ask user if they wish to play again
            PrintColouredMsg(ConsoleColor.DarkYellow, "Play again? [Y / N]");

            // check user input, if y or Y, then return true, else false
            string input = Console.ReadLine();

            if (input.ToLower() == "y")
            {
                return true;
            }
            return false;

        }
    }
}
