        static void Main(string[] args)
        {
            List<string[]> values = new List<string[]>();
            using (StreamReader reader = new StreamReader("TextFile1.txt"))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    values.Add(line.Split(' '));
                }
            }
            foreach (string[] sa in values)
            {
                foreach (string s in sa)
                    Console.Write(s + " ");
                Console.WriteLine();
            }
            Console.ReadLine();
        }
