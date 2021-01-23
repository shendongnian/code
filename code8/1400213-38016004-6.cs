    var paragraphe = html.DocumentNode.SelectNodes(".//p[not(descendant::p)]");
    for (int i = 0; i < paragraphe.Count; i++)
    {
        var parent = paragraphe[i].ParentNode;
        if (parent.Name == "div" &&
            parent.ChildAttributes("edth_correction").Any(a => a.Value == "N"))
        {
            // do work
        }
    }
