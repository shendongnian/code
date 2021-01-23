    public class DeviceData {
        public DeviceList Devices { get; set; }
    }
    
    public class DeviceList {
        [JsonProperty(PropertyName = "AppleTV2,1")]
        public Device AppleTV21 { get; set; }
    
        [JsonProperty(PropertyName = "AppleTV3,1")]
        public Device AppleTV31 { get; set; }
        // continue ...
    }
    
    public class Device {
        public string Name { get; set; }
        public string BoardConfig { get; set; }
        public string Platform { get; set; }
        public string Cpid { get; set; }
        public string Bdid { get; set; }
        public Firmware[] Firmwares { get; set; }
    }
    
    public class Firmware {
        public string Version { get; set; }
        public string BuildId { get; set; }
        public string Sha1Sum { get; set; }
        public string Md5Sum { get; set; }
        public int Size { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime UploadDate { get; set; }
        public string Url { get; set; }
        public bool Signed { get; set; }
        public string Filename { get; set; }
    }
