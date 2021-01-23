    class ResFile
    {
        [DataMember(Name = "name")]
        public string Name { get; set; } 
        [DataMember(Name = "hash")]
        public string Hash { get; set; } 
        [DataMember(Name = "size")]
        public int Size { get; set; }
        public ResFile () { }
    }
    [DataContract]
    class ResFileCollection
    {
        [DataMember(Name ="files")]
        public Dictionary<string, ResFile> Files { get; set; }
    }
