    public class TreeItem
    {
        public int Id { get; set; }
        public int? LeftId { get; set; }
        public int? RightId { get; set; }
        [ForeignKey("LeftId")]
        [InverseProperty("Parent1")]
        public virtual TreeItem Left { get; set; }
        [ForeignKey("RightId")]
        [InverseProperty("Parent2")]
        public virtual TreeItem Right { get; set; }
        [InverseProperty("Left")]
        public virtual ICollection<TreeItem> Parent1 { get; set; }
        [InverseProperty("Right")]
        public virtual ICollection<TreeItem> Parent2 { get; set; }
    }
