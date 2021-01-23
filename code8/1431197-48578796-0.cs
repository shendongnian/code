    public class ItemA()
    {
        public virtual ICollection<ItemB> Items{ get; set; }
    }
    
    public class ItemB()
    {
        [Required] // This set's the constraint
        public virtual ItemA Parent { get; set; }
        public virtual ICollection<ItemC> Items{ get; set; }
    }
