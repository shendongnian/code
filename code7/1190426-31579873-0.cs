    class Entity_1
    {    
        public int Id { get; set; }
        public virtual ICollection<Entity_2> Entity_2s{ get; set; }
    }
    class Entity_2
    {    
        public int Id { get; set; }
        public int Entity_1Id { get; set; }
        public virtual Entity_1 Entity_1 { get; set; }
    }
