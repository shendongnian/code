    public class UFMLine
    {
        public UFMTemplate elementTag { get; set; }
        public int posX1 { get; set; }
        public int posY1 { get; set; }
        public int posX2 { get; set; }
        public int posY2 { get; set; }
        public string property { get; set; }
        public string hierStr { get; set; } = string.Empty;
        public List<UFMLine> ufmLines { get; set; } = new List<UFMLine>();
    }
