    [DataContract]
    struct TwitterProfile
    {
        [DataMember(Name = "name")]
        public String Name { get; set; }
        [DataMember(Name = "profile_image_url")]
        public String Avatar { get; set; }
        [DataMember(Name = "statuses_count")]
        public Int32 Tweets { get; set; }
        [DataMember(Name = "followers_count")]
        public Int32 Followers { get; set; }
        [DataMember(Name = "friends_count")]
        public Int32 Following { get; set; }
    }
