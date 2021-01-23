    class Program
    {
        static void Main(string[] args)
        {
            
            char ch;
            Console.Write("Enter a string:");
            string str = Console.ReadLine();
            for (ch = 'A'; ch <= 'Z'; ch++)
            {
                int count = 0;
                for (int i = 0; i < str.Length; i++)
                {
                    if (ch==str[i] || str[i] == (ch + 32))
                    {
                        count++;
                    }
                }
                if (count > 0)
                {
                    Console.WriteLine("Char {0} having Freq of {1}", ch, count);
                }
            }
            Console.Read();
        }
    }
