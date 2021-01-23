    public void Test()
    {
        const string attributeName = "name";
        XElement doc = XElement.Parse(@"<xml><elem id=""1"" /><anotherElem name=""test"" /></xml>");
        var items = (from el in doc.Descendants()
            where el.Attribute(attributeName) != null
            select new
            {
                Name = el.Name.LocalName,
                Value = el.Attribute(attributeName).Value
            }).ToDictionary(o => o.Name, o => o.Value);
        Assert.AreEqual(1, items.Count);
        Assert.AreEqual(true, items.ContainsKey("anotherElem"));
        Assert.AreEqual("test", items["anotherElem"]);
    }
