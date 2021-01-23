    public class StockChecklist
    {
        public StockChecklist()
        {
            qty1p1 = new Info { tag = "uniqueval23456", value = "", reference = "" };
            qty1p2 = new Info { tag = "uniqueval3736", value = "", reference = "" };
            qty2 = new Info { tag = "uniqueval97357", value = "", reference = "" };
            qty3p1 = new Info { tag = "uniqueval88356", value = "", reference = "" };
            qty3p2 = new Info { tag = "uniqueval62346", value = "", reference = "" };
            qty3p3 = new Info { tag = "uniqueval09876", value = "", reference = "" };
            qty3p4 = new Info { tag = "uniqueval62156", value = "", reference = "" };
            qty4 = new Info { tag = "uniqueval25326", value = "", reference = "" };
        }
        public Info qty1p1 { get; private set; }
        public Info qty1p2 { get; private set; }
        public Info qty2 { get; private set; }
        public Info qty3p1 { get; private set; }
        public Info qty3p2 { get; private set; }
        public Info qty3p3 { get; private set; }
        public Info qty3p4 { get; private set; }
        public Info qty4 { get; private set; }
    }
