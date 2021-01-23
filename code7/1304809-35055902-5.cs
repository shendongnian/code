    class MyFile
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public string Name { get; set; }
        public MyFile()
        {
            Id = Guid.NewGuid();
        }
    }
