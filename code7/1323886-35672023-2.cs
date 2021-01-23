    [DataContract]
    class ImageDTO
    {
        [DataMember(Order = 1)]
        public int Width { get; set; }
        [DataMember(Order = 2)]
        public int Height { get; set; }
        [DataMember(Order = 3)]
        public ImageFormat Format { get; set; }
        [DataMember(Order = 4)]
        public byte[] Data { get; set; }
        [DataMember(Order = 5)]
        public string AltUrl { get; set; }
    }
