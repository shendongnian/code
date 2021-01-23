        bool isFirst = true;
    
        foreach (var name in names) 
        {
               
                var id = string.Format(
                "{0}_{1}_{2}",
                htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix,
                metaData.PropertyName,
                name
                );
                 
                var attribs = new RouteValueDictionary(htmlAttributes) { { "id", id }, { "checked", isFirst} }; 
                var radio = htmlHelper.RadioButtonFor(expression, name, attribs).ToHtmlString();
                var field = fields.Single(f => f.Name == name);
    
                if(isFirst)
                {
                   isFirst = false;                
                }
       }
