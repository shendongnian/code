    public class CarUploadViewModel
    {
        [Required]
        public string ImageInfo{ get; set; }
    
        [DataType(DataType.Upload)]
        HttpPostedFileBase ImageUpload { get; set; }
    }
