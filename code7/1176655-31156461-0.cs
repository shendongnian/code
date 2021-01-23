    public static void Main()
    {
        XmlDocument doc = new XmlDocument();
        var root = doc.CreateElement("grammar");
        doc.AppendChild(root);
            
        var item = doc.CreateElement("item");
        var text = doc.CreateTextNode("Abbottabad");
        item.AppendChild(text);
            
        var tag = doc.CreateElement("tag");
        tag.InnerText = "out = \"Abbott aabaad\";";
        item.AppendChild(tag);
        root.AppendChild(item);
        Console.WriteLine(doc.OuterXml);
    }
