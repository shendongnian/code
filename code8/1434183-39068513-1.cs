    class MyDocument
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Vendor { get; set; }
    }
    ...
    var collection = db.GetCollection <MyDocument> ("parts");
