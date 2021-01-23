    public class Setting
    {
        public Guid Id { get; set; }
        public bool Value { get; set; }
        [NonSerialized]
        public string Description { get; set; }
    }
