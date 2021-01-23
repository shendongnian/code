    [Serializable]
    public class Header
    {
        public Header()
        {
        }
        public string Product { get; set; }
        public DateTime EmisionDate{ get; set; }
        public string Number { get; set; }
        public Person Person { get; set; }
    }
