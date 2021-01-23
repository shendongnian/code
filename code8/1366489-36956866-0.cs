    class Player {
        //player properties
        // ...
        public Player(...) { ... }
        public string ToString() { ...}
    } //end of class player 
    class ReadCVSFile {
        private List<string> content = new List<string>();
        public string FileName { get; set; }
        public string Delimiter { get; set; }
        public ReadCSVFile(string fn, string delim = "|")
        {
            FileName = fn;
            Delimiter = delim;
        }
        public void Load() { ...}
        static void RunReadCSVFile()
        {
            var f = new ReadCSVFile(@"C:\Temp\car1.txt");
            f.Load();
        }
    } 
