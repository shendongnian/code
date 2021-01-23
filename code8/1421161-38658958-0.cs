    class BaseA
    {
        public string ObjectType { get; set; } //enum would be a good choice.
        public int ID { get; set; }
                 (or)
        public Dictionary<string,int> AllProperties { get; set; }
    }
