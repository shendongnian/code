    class text
    {
        public int IDnum { get; set; }
        public string file { get; set; }
        public int lineNum { get; set; }
        public string FileText { get; set; }
        public string lineType { get; set; }
        public override string ToString()
        {
            return string.Format("{0}, {1}", this.file, this.FileText);
        }
    }
