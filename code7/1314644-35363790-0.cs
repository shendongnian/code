    var paragraphes = html.DocumentNode.SelectNodes("//p");
    
    foreach (var p in paragraphes)
    {
        foreach (var span in p.SelectNodes("span"))
            p.RemoveChild(span);
    
        string innerTextOfP = Regex.Replace(p.InnerText, @"\s+", " ");
    }
