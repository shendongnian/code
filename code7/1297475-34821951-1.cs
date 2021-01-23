    var styles = htmlDoc.DocumentNode.SelectNodes("//@style");                    
    if (styles != null)
    {
    foreach (var item in styles)
    {
    item.Attributes["style"].Remove();
    }
    }
