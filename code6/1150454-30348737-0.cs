    var s = "<span id=\"myspan\">2,500</span><span id=\"myspan\">500</span>";
    var  doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(s);
    foreach (var node in doc.DocumentNode.ChildNodes.Where(n => n.Name == "span"))
    {
        string value = node.InnerHtml;
        // here you can transform string value to integer and so on
        Console.WriteLine(value);
    }
