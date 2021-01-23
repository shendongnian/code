    class ConsoleFilteredOutput : TextWriter
        {
            public override void Write(char value)
            {
    
            }
    
            public override Encoding Encoding
            {
                get { return Encoding.Unicode; }
            }
        }
    
        static TextWriter standardOutputWriter = Console.Out;
        static ConsoleFilteredOutput filteredOutputWriter = new ConsoleFilteredOutput();
    
        static void WriteUnfiltered(string text)
        {
            Console.SetOut(standardOutputWriter);
            Console.WriteLine(text);
            Console.SetOut(filteredOutputWriter);
        }
    
        static void Main(string[] args)
        {
            Console.SetOut(filteredOutputWriter);
    
            do
            {
                ConsoleKeyInfo keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.RightArrow:
                        WriteUnfiltered(keyinfo.Key.ToString());
                        break;
                }
            }
            while (true);
        }
    }
`
