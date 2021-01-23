    public class Advertisement
    {
        public int ID { get; set; }
        [Required]
        public string ImageURL { get; set; }
        [Required]
        public string DestinationURL { get; set; }
    }
    public class AdvertisementHistory
    {
        public int ID { get; set; }
        public int AdvertisementID { get; set; }
        [Required]
        [ForeignKey("AdvertisementID")]
        public Advertisement Advertisement { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public int Month { get; set; }
        [Required]
        public int Clicked { get; set; }
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<AdvertisementHistory>()
            .HasIndex(p => new { p.AdvertisementID, p.Year, p.Month })
    }  
