    class text
    {
        public int IDnum { get; set; }
        public string file { get; set; }
        public int lineNum { get; set; }
        public string FileText { get; set; }
        public string lineType { get; set; }
        public override ToString()
        {
            return fileText; // return here whatever you want to use
        }
    }
