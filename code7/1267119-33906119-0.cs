    public class Parent
    {
        [Key, MaxLength(30)]
        public virtual string Name { get; set; }
        [InverseProperty("Parent")]
        public virtual ICollection<Child> Children { get; set; }
    }
    public class Child
    {
        [Key, Column(Order = 1), MaxLength(30)]
        public virtual string Parent_Name { get; set; }
        [Key, Column(Order = 2), MaxLength(30)]
        public virtual string Name { get; set; }
        public virtual string Reference_Name { get; set; }
        [ForeignKey("Parent_Name")]
        public virtual Parent Parent { get; set; }
        [ForeignKey("Reference_Name")]
        public virtual Reference Reference { get; set; }
        public Child Clone()
        {
            return new Child
            {
                Parent_Name = this.Parent_Name,
                Name = this.Name,
                Reference_Name = this.Reference_Name,
                Parent = this.Parent,
                Reference = this.Reference
            };
        }
    }
    public class Reference
    {
        [Key, MaxLength(30)]
        public virtual string Name { get; set; }
    }
    public class SomethingElse
    {
        [Key, MaxLength(30)]
        public virtual string Name { get; set; }
    }
