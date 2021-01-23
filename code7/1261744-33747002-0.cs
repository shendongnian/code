    public class ImageTest
    {
        [DataContract(Namespace = "")]
        [KnownType(typeof(FileImage))]
        public abstract class ImageBase
        {
        }
        [DataContract(Name = "File", Namespace = "")]
        public sealed class FileImage : ImageBase
        {
            [DataMember(Name = "name")]
            public string name { get; set; }
            [DataMember(Name = "url")]
            public string url { get; set; }
        }
        [DataContract(Namespace = "")]
        public class Result
        {
            [DataMember]
            public string createdAt { get; set; }
            [IgnoreDataMember]
            public FileImage image { get { return imageBase as FileImage; } set { imageBase = value; } }
            [DataMember(Name = "image")] // Need not be public if DataMember is applied.
            ImageBase imageBase { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public string objectId { get; set; }
            [DataMember]
            public string updatedAt { get; set; }
        }
        public class RootObject
        {
            public List<Result> results { get; set; }
        }
    }
