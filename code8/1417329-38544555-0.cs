    public void TestDeserialize()
    {
        var appValue = Persister.ReadFromXml("before.xml");
        Persister.WriteToXml(appValue, "after.xml");
    
        var before = File.ReadAllText("before.xml");
        var after = File.ReadAllText("after.xml");
        bool before_equals_after = before.Equals(after, StringComparison.OrdinalIgnoreCase);
    }
