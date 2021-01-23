    public class CameraAttributeAudio
    {
        [Key]
        [ForeignKey("Attributes")] 
        public int AttributeId { get; set; }
        [MaxLength(50)] 
        public string SupportedFormats { get; set; }
    
        public CameraAttribute Attributes { get; set; }
    }
