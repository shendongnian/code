    using System;
    namespace ConsoleApp2
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // Set up an infinite loop that will allow us to forever type unless 'Q' is pressed.
                while(true)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    // If Q is pressed, we quit the app by ending the loop.
                    if (pressedKey.Key == ConsoleKey.Q)
                    {
                        break;
                    }
                    // Handle the pressed key character.
                    OnKeyDown(pressedKey.KeyChar);
                }
            }
            private static void OnKeyDown(char key)
            {
                int number;
                // Try to parse the key into a number.
                // If it fails to parse, then we abort and listen for the next key.
                // It will fail if anything other than a number was entered since integers can only store whole numbers.
                if (!int.TryParse(key.ToString(), out number))
                {
                    return;
                }
                // If we get here, then the user entered a number.
                // Apply our logic for handling numbers
                ChangeColorOfPreviousCharacters(ConsoleColor.Green, key.ToString());
            }
            private static void ChangeColorOfPreviousCharacters(ConsoleColor color, string originalValue)
            {
                // Store the original foreground color of the text so we can revert back to it later.
                ConsoleColor originalColor = Console.ForegroundColor;
                // Move the cursor on the console to the left 1 character so we overwrite the character previously entered
                // with a new character that has the updated foreground color applied.
                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                Console.ForegroundColor = color;
                // Re-write the original character back out, now with the "Green" color.
                Console.Write(originalValue);
                // Reset the consoles foreground color back to what ever it was originally. In this case, white.
                Console.ForegroundColor = originalColor;
            }
        }
    }
