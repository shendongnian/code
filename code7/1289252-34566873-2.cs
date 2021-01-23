    class Master
    {
        public int ID { get; set; }
        public virtual ICollection<PropertyBase> Properties { get; set; }
    }
