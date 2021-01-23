    public class MyData
    {
        public string ClientName { get; set; }
        public List<DnoList> DnoLists { get; set; }
    }
    public class DnoList
    {
        public int DnoId { get; set; }
        public string Dno { get; set; }
        public List<DfullList> DfullLists { get; set; }
    }
    public class DfullList
    {
        public int DfullId { get; set; }
        public string Dfull { get; set; }
    }
