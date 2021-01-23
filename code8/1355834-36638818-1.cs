    [DataContract]
    public class RequestMetaDataXml
    {
        [DataMember(Name = "Title")]
        public string Title { get; set; }
        [DataMember(Name = "ExpiryDate")]
        public string ExpiryDate { get; set; }
        [DataMember(Name = "AllowDownload")]
        public string AllowDownload { get; set; }
        [DataMember(Name = "IsShare")]
        public string IsShare { get; set; }
        [DataMember(Name = "IncludeMetadata")]
        public string IncludeMetadata { get; set; }
        [DataMember(Name = "IsReel")]
        public string IsReel { get; set; }
        [DataMember(Name = "IsSecuredPublish")]
        public string IsSecuredPublish { get; set; }
        [DataMember(Name = "Notifications")]
        public NotificationId Notifications { get; set; }
        [DataMember(Name = "CoverArt")]
        public CoverArt Coverart { get; set; }
        [DataMember(Name = "ProfileInfo")]
        public ProfileInfo Profileinfo { get; set; }
    }
    [DataContract]
    public class NotificationId
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }
        [DataMember(Name = "Type")]
        public string Type { get; set; }
    }
    [DataContract]
    public class CoverArt
    {
        [DataMember(Name = "UploadedFileName")]
        public string UploadedFileName { get; set; }
    }
    [DataContract]
    public class ProfileInfo
    {
        [DataMember(Name = "Watermark")]
        public WaterMark WaterMark { get; set; }
    }
    [DataContract]
    public class WaterMark
    {
        [DataMember(Name = "VideoWatermark")]
        public VideoWatermark VideoWatermark { get; set; }
    }
    [DataContract]
    public class VideoWatermark
    {
        [DataMember(Name = "WaterMarkInfo")]
        public WaterMarkInfo WaterMarkInfo { get; set; }
    }
    [DataContract]
    public class WaterMarkInfo
    {
        [DataMember(Name = "Type")]
        public string Type { get; set; }
        [DataMember(Name = "FreeText")]
        public string FreeText { get; set; }
        [DataMember(Name = "Position")]
        public string Position { get; set; }
        [DataMember(Name = "Size")]
        public string Size { get; set; }
        [DataMember(Name = "LogoId")]
        public string LogoId { get; set; }
    }
