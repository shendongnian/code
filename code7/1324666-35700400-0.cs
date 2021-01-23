            static void Main(string[] args)
        {
            Console.WriteLine("Please Enter 5 characters:");
            char[] data = new char[5];
            for (int i = 0; i < 5; i++)
            {
                data[i] = Console.ReadKey().KeyChar;
            }
            Console.WriteLine("");
            Array.Sort(data);
            Console.WriteLine("Answer is:" );
            foreach (var ch in data)
            {
                Console.Write(ch);
            }
            Console.Read();
        }
