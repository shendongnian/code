        static char ReadChar(string prompt)
        {
            // Screen Prompt
            Console.Write(prompt);
            // Read a Character
            return Console.ReadKey(false).KeyChar;
        }
        static int ReadNumber(string prompt)
        {
            // Screen Prompt
            Console.Write(prompt);
            int result=-1;
            // Reads a number and onverts it into an integer
            int.TryParse(Console.ReadLine(), out result);
            return result;
        }
        // Caution, this modifies the contents of `messages`
        static void addLetters(params char[][] messages)
        {
            // Read message index (first=1, second=2, etc)
            int Mnumber=ReadNumber("- Message #: ");
            // Read letter
            char letter=ReadChar("Letter: ");
            // Read placement position
            int position=ReadNumber("\nPosition: ");
            // Get the right message
            char[] current_message=messages[Mnumber-1];
            // Assigns a letter to the message
            current_message[position]=letter;
        }
        static void Main(string[] args)
        {
            int n=50; //Store the size instead of hard coding it all over your code
            char[] array1=new char[n];
            char[] array2=new char[n];
            for (int i=0; i<n; i++)
            {
                array1[i]='*';
                array2[i]='*';
            }
            addLetters(array1, array2);
        }
