        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid ID { get; set; }
        [BsonElement("Artist")]
        public string Name { get; set; }
        [BsonElement("Song")]
        public string Song { get; set; }
