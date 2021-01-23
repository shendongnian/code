    class Program
    {
        public static string[][] ReadFiles(string folder, params string[] files)
        {
            return files.Select((fn) => File.ReadAllLines(Path.Combine(folder, fn))).ToArray();
        }
        static void Main(string[] args)
        {
            
            var data = ReadFiles(@"data", 
                "Month.txt",
                "Year.txt",
                "WS1_AF.txt",
                "WS1_Rain.txt",
                "WS1_Sun.txt",
                "WS1_TMin.txt",
                "WS1_TMax.txt" );
        }
    }
