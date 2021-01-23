    [ServiceContract]
        public interface IImageService
        {
            [OperationContract]
            bool CheckQualityOfImage(CheckQuality objCheckQuality);
        }
    
        
        [DataContract]
        public class CheckQuality
        {
            [DataMember]
            public MemoryStream ImageData { get; set; }
            [DataMember]
            public string ImageFileName{ get; set; }
        }
