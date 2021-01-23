    public class Info
    {
        public string tag { get; set; }
        public string value { get; set; }
        public string reference { get; set; }
    }
    public class StockChecklist
    {
        public Info qty1p1 { get; } = new Info { tag = "uniqueval23456", value = "", reference = "" };
        public Info qty1p2 { get; } = new Info { tag = "uniqueval3736", value = "", reference = "" };
        public Info qty2 { get; } = new Info { tag = "uniqueval97357", value = "", reference = "" };
        public Info qty3p1 { get; } = new Info { tag = "uniqueval88356", value = "", reference = "" };
        public Info qty3p2 { get; } = new Info { tag = "uniqueval62346", value = "", reference = "" };
        public Info qty3p3 { get; } = new Info { tag = "uniqueval09876", value = "", reference = "" };
        public Info qty3p4 { get; } = new Info { tag = "uniqueval62156", value = "", reference = "" };
        public Info qty4 { get; } = new Info { tag = "uniqueval25326", value = "", reference = "" };
    }
