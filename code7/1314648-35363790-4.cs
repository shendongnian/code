    var paragraphes = html.DocumentNode.SelectNodes("//p");
    
    foreach (var p in paragraphes)
    {
        var clone = p.Clone(); // to avoid modification of original html
        foreach (var span in clone.SelectNodes("span"))
            clone.RemoveChild(span);
        foreach (var div in clone.SelectNodes("div[not(@class='contenu')]"))
            clone.RemoveChild(div);
        // remove other nodes which you want to skip here
    
        string innerTextOfP = Regex.Replace(clone.InnerText, @"\s+", " ");
    }
