    class TableLevel1
    {
        public virtual TableLevel2 TableLevel2 { get; set; }
    }
    class TableLevel2
    {
        public virtual TableLevel3 TableLevel3 { get; set; }
        public virtual TableLevel3 AnotherTableLevel3 { get; set; }
    }
