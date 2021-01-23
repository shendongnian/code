        static void Main(string[] args)
        {
            var lines = System.IO.File.ReadAllLines(@"C:\palindromy.txt");
            string longest = string.Empty;
            string shortest = string.Empty;
            foreach (var line in lines)
            {
                if (line.Length == 0) continue;
                char[] charArray = line.ToCharArray();
                Array.Reverse(charArray);
                string reversedLine = new string(charArray);
                if (line.Equals(reversedLine, StringComparison.OrdinalIgnoreCase))
                {
                    if (line.Length > longest.Length)
                    {
                        longest = line;
                    }
                    if (line.Length < shortest.Length || shortest.Length == 0)
                    {
                        shortest = line;
                    }
                }
            }
            Console.WriteLine(longest);
            Console.WriteLine(shortest);
        }
