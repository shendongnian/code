    public class EventInfo
    {
        [Column(Name = "EventID")]
        public string EventID { get; set; }
        [Column(Name = "EventName")]
        public string EventName { get; set; }
        [Column(Name = "IsJoint")]
        public bool IsJoint { get; set; }
    }
    public class ImageInfo
    {
        [Column(Name = "ImageID" )]
        public string ImageID { get; set; }
        [Column(Name = "EventMediaFolder")]
        public string EventMediaFolder { get; set; }
        [Column(Name = "Image")]
        public string Image { get; set; }
        [Column(Name = "DateTime")]
        public string DateTime { get; set; }
        [Column(Name = "ImageDescription")]
        public string ImageDescription { get; set; }
        [Column(Name = "Action")] 
        public string Action { get; set; }
    }
