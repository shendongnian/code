    var paragraphes = html.DocumentNode.SelectNodes("//p");
    
    foreach (var p in paragraphes)
    {
        var clone = p.Clone(); // to avoid modification of original html
        foreach (var span in clone.SelectNodes("span"))
            clone.RemoveChild(span);
    
        string innerTextOfP = Regex.Replace(clone.InnerText, @"\s+", " ");
    }
