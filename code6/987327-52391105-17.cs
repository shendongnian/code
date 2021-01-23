    public partial class ITEM_ATCHMT
    {
        [Key]
        public Guid ATCHMT_ID { get; set; }
        public int ITEM_ID { get; set; }
        [ForeignKey("ITEM_ID")]
        public virtual ITEM item { get; set; }
        [Required]
        [StringLength(50)]
        public string USER_NAME_DESC { get; set; }
        [Required]
        [StringLength(250)]
        public string FILE_NAME_TXT { get; set; }
        [Required]
        public byte[] FILE_CNTNT_CD { get; set; }
        [Required]
        [StringLength(10)]
        public string FILE_TYPE_DESC { get; set; }
        public DateTime CREATED_DT { get; set; }
    } 
