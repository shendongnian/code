    public HtmlGenericControl RenderMenu(List<item> nodes)
    {
        if (nodes == null)
            return null;
    
        var ul = new HtmlGenericControl("ul");
    
        foreach (Node node in nodes)
        {
            var li = new HtmlGenericControl("li");
            li.InnerText = node.texte;
    
            if(node.listeItems != null)
            {
                li.Controls.Add(RenderMenu(node.listeItems));
            }
    
            ul.Controls.Add(li);
        }
    
        return ul;
    }
