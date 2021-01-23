    public class Labels
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public Nullable<bool> Active { get; set; }
        public string Operation { get; set; }
        public string Value { get; set; }
    }
