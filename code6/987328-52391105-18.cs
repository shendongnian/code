    public partial class ITEM
    {
        [Key]
        public int ITEM_ID { get; set; }
        [Required]
        [StringLength(50)]
        public string NAME { get; set; }
    }
