     static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\palindromy.txt");
            private string longest;
            private string shortest;
            foreach (string line in lines)
            {
                char[] charArray = line.ToCharArray();
                for (int i = 0; i < 1; i++)
                {
                    Array.Reverse(charArray);
                    bool a = charArray.SequenceEqual(line);
                    if(a)
                    {
                          if(a.Length > longest.length)
                             {
                                  longest = a;
                             }
                          if(a.Length<shortest.length)
                             {
                                shortest = a;
                             }
                    }
                }
            }
               Console.WriteLine(longest);
               Console.WriteLine(shortest);
        }
