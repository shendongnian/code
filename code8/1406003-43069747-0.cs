    public class Subscript
    {
        [Key, Column(Order = 0)]
        public long ID { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public string ChatType { get; set; }
        [ForeignKey("Channel")]
        public int? ChannelId { get; set; }
        public virtual Channel Channel { get; set; }
        [ForeignKey("Watermark") ,Column(Order = 1)]
        public int? Watermark_Id { get; set; }
        [ForeignKey("Watermark"), Column(Order = 2)]
        public string Watermark_Title { get; set; }
        public virtual Watermark Watermark { get; set; }
}
    public class Watermark
    {
        [Key, Column(Order = 0), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Key, Column(Order = 1, TypeName = "NVARCHAR")]
        [StringLength(100)]
        public string Title { get; set; }
    }
