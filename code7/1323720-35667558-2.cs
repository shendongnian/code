    public class YogaClass
    {
        [Key]
        public int YogaClassId { get; set; }
        public YogaStyle YogaStyle { get; set;}
        [Key]
        public string BandyProfileRefId { get; set; }
        [ForeignKey("BandyProfileRefId")]
        public virtual BandyProfile.BandyProfile BandyProfile { get; set; }
    }
