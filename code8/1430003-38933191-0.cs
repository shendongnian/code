    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;
            List<string> wordsTyped = new List<string>();
            for (;;)
            {
                Console.Write("Write phrase: ");
                string row = Console.ReadLine();
                if(row == "exit")
                    break;
                Console.WriteLine(i++ + ". " + (row));
                
                if(wordsTyped.Contains(row))
                    Console.WriteLine("Already inserted, type again");
                wordsTyped.Add(row);
            }
            File.WriteAllLines("lines.txt", wordsTyped.ToArray());
            Console.Read();
        }
    }
