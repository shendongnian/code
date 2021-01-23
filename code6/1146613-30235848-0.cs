        public class ItemBase
        {
            [ScaffoldColumn(false)]
            [Key]
            public long ItemID {get; set;}
    
            [ScaffoldColumn(false)]
            public virtual DateTime CreatedDate { get; set; }
    
            [ScaffoldColumn(false)]
            public virtual DateTime ModifiedDate { get; set; }
        }
