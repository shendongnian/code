    private void _LoadUsers()
    {
        _users = new List<TestUser>();
    
        string path = Path.Combine(_projectNamespace, "users.xml");
        var stream = new FileStream(path, FileMode.Open);
        var reader = new XmlTextReader(new StreamReader(stream));
        while (reader.ReadToFollowing("user"))
        {
            var serializer = new XmlSerializer(typeof(TestUser));
            _users.Add((TestUser)serializer.Deserialize(reader.ReadSubtree()));
        }
        stream.Close();
    }
