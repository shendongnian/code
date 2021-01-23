         static void Main(string[] args)
            {
                string word = "AbcdefHig";
                try
                {
                    Console.Write(word.Substring(LastCapital(word)));
    
                }
                catch(Exception e)
                {
                    Console.Write("no capital letter");
                }
            }
    
          private static int LastCapital(string word)
            {
                for(int i = word.Length - 1; i >= 0; i--)
                {
                    if (Char.IsUpper(word[i]))
                    {
                        return i;
                    }
                }
                return -1;
            }
