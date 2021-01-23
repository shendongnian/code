        static void addLetters(char[] messageOne, char[] messageTwo)
        {
            char Mnumber;
            char letter;
            string pos;
            int position;
            try
            {
                do
                {
                    Console.Write("- Message #: ");
                    Mnumber = Console.ReadKey().KeyChar;
                    Console.WriteLine();
                }
                while (Mnumber != '1' && Mnumber != '2');
                Console.Write("\nLetter: ");
                letter = Console.ReadKey().KeyChar;
                Console.Write("\nPosition: ");
                pos = Console.ReadLine();
                position = Int32.Parse(pos);
                if (Mnumber == '1')
                    messageOne[position - 1] = letter;
                else
                    messageTwo[position - 1] = letter;
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format, position must be an integer");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Position out of array bounds");
            }
            finally
            {
                Console.Read();
            }
        }
