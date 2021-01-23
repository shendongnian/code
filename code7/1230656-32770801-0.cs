    class Program
        {
            static void Main(string[] args)
            {
                DualOut.Init();
                Console.WriteLine("Hello");
    
    
                Console.ReadLine();
            }
        }
    
        public static class DualOut
        {
            private static TextWriter _current;
    
            private class OutputWriter : TextWriter
            {
                public override Encoding Encoding
                {
                    get
                    {
                        return _current.Encoding;
                    }
                }
    
                public override void WriteLine(string value)
                {
                    _current.WriteLine(value);
                    File.WriteAllLines("Output.txt", new string[] { value });
                }
            }
    
            public static void Init()
            {
                _current = Console.Out;
                Console.SetOut(new OutputWriter());
            }
        }
