    private class Gtrx
    {
        public int Freq { get; set; }
        public int TrxNo { get; set; }
        public string TrxName { get; set; }
        public int CellId { get; set; }
        public bool IsMainBcch { get; set; }
    }
    private class Gcell
    {
        public int CellId { get; set; }
        public string CellName { get; set; }
        public string Mcc { get; set; }
        public int Lac { get; set; }
        public int Ci { get; set; }
    }
