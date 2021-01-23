    List<int> collection = new List<int>(){ 0, 1, 2, 3 };
    using (var fs = new StreamWriter("serialized.txt"))
    {
        XmlSerializer serializer = new XmlSerializer(collection.GetType());
        serializer.Serialize(fs, collection.Where(x => x != 0).ToList());
    }
