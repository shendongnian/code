    class Program
    {
        static void Main(string[] args)
        {
            string input1, input2;
            Console.WriteLine("SoundDex is a phonetic algorithm which allows a user to encode words which sound the same into digits."
                + "The program allows the user essentially to enter two names and get an encoded value.");
            input1 = GetValidInput("Please enter a name -> ");
            input2 = GetValidInput("Please enter a second name -> ");
            soundex soundex = new soundex(); // sets new instance variable and assigns from the method
            Console.WriteLine(soundex.GetSoundex(input1)); // gets the method prior to whatever the user enters
            // do whatever you want with input2 as well
            Console.ReadLine(); // reads the users input
        }
        static string GetValidInput(string prompt)
        {
            while (true)
            {
                string input;
                Console.WriteLine(prompt); // asks user for an input
                input = Console.ReadLine();
                // Make sure the user entered something
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("Error! No input."); // displays an error to the user
            }
        }
    }
