    foreach (XmlNode rssNode in rssNodes)
    {
        ...
        HtmlGenericControl div = new HtmlGenericControl("div");
        noticias.Controls.Add(div);
        
        HtmlGenericControl li = new HtmlGenericControl("li");
        div.Controls.Add(li);
        
        HtmlGenericControl span = new HtmlGenericControl("span");
        span.InnerText = title;
        ...
    }
