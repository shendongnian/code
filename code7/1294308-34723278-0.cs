    public class ImageFile : BaseEntity
    {
        [Key]
        Guid Guid { get; set; }
        public string Name { get; set; }        
        public string Extension { get; set; }
    
        public long Size { get; set; }
        public byte[] FileContent { get; set; }    
        
        public Guid ProjectImageGuid { get; set; }
    
        [ForeignKey("ProjectImageGuid")]            
        public ProjectImage ProjectImage { get; set; }
    }
    
    public class ProjectImage : BaseEntity
    {    
        public string Description { get; set }            
        public Guid ThumbnailGuid { get; set; }        
        public Guid FullSizeImageGuid { get; set; }
    
        [ForeignKey("ImageFileGuid")]
        public ImageFile Thumbnail { get; set; }
    
        [ForeignKey("ImageFileGuid")]
        public ImageFile FullSizeImage { get; set; }
    }
