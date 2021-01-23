    public static void SetElement(int id, string text)
    {
        var doc = XDocument.Load(PATH);
    
        var element = doc.Descendants()
            .Single(e => (int)e.Attribute("id") == id);
    
        element.ReplaceNodes(new XCData(text));
    
        doc.Save(PATH);
    }
