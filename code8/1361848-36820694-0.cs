    string path = "..."; // path to file
    string ns = "..."; // specify correct namespace
    using (var reader = XmlReader.Create(path))
    {
        reader.ReadToFollowing("name", ns);
        string name = reader.ReadElementContentAsString();
        Console.WriteLine(name);
    }
