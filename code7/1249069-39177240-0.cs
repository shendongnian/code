    public void begin()
        {   List<string> lines = new List<string>();
            string line = "";
            Console.WriteLine("paste text to begin");
            var Chars = Console.ReadKey(true);
            int charCount = 0;
            DateTime beg = DateTime.Now;
            do
            {
                Chars = Console.ReadKey(true);
                if (Chars.Key == ConsoleKey.Enter)
                {
                    lines.Add(line);
                    line = "";
                }
                else
                {
                    line += Chars.KeyChar;
                    charCount++;
                }
             
               
            } while (charCount < 100000);
            Console.WriteLine("100,000 characters ("+lines.Count.ToString("N0")+" lines) in " + DateTime.Now.Subtract(beg).TotalMilliseconds.ToString("N0")+" milliseconds");
        }
