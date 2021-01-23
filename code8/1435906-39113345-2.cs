    Class SubItem
    {
        [Key] int id {get; set;}
        public string name {get;set;}
        public int? MainClassId { get; set;}
        public virtual MainClass MainClass { get; set; }
    }
