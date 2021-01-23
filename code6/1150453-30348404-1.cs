    var txt = "<span id=\"myspan\">2,500</span><span id=\"myspan\">500</span>";
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(txt);
    foreach (var node in doc.DocumentNode.ChildNodes.Where(p => p.Name == "span" && p.HasAttributes && p.GetAttributeValue("id", string.Empty) == "myspan"))
    {
       var val = node.InnerHtml;
       Console.WriteLine(val.Replace(",", string.Empty));
    }
