    class ParentEntity
    {
        [Key]
        public int Id { get; protected set; }
    
        public string Property1 { get; set; }
        public string Property2 { get; set; }
    
        public virtual ChildEntity child { get; set; } // virtual to enable lazy loading
    }
