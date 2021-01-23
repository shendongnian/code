    public class TestId
    {
        public TestId() : this(-1, null) { }
        public TestId(int id) : this(id, null) { }
        public TestId(string name) : this(-1, name) { }
        public TestId(int id, string name)
        {
            this.ID = id;
            this.TestName = name;
            this.Manoeuvres = new List<ManoeuvresId>();
        }
        public string TestName { get; set; }
        public int ID { get; set; }
        public IList<ManoeuvresId> Manoeuvres { get; set; }
    }
