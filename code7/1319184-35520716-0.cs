    public class MyURL
    {
        [Key]
        [Column("FacilityId")]
        public int FacilityId { get; set; }
        [Column("Url")]
        public string Url { get; set; }
    }
