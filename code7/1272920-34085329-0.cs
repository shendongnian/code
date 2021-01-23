    @{
        int @index = 0;
        string @xml = Model;
        if (@xml == null)
            @xml = "";
        Regex @seeRegex = new Regex("<( *)see( +)cref=\"([^\"]):([^\"]+)\"( *)/>");//Regex("<see cref=\"T:([^\"]+)\" />");
        Match @xmlSee = @seeRegex.Match(@xml);
        string @typeAsText = "";
        Type @tp;
        ModelDescriptionGenerator modelDescriptionGenerator = (new HelpController()).Configuration.GetModelDescriptionGenerator();
    }
    @if (xml !="" && xmlSee != null && xmlSee.Length > 0)
    {
        while (xmlSee != null && xmlSee.Length > 0)
        {
        
                @MvcHtmlString.Create(@xml.Substring(@index, @xmlSee.Index - @index))
            int startingIndex = xmlSee.Value.IndexOf(':')+1;
            int endIndex = xmlSee.Value.IndexOf('"', startingIndex);
            typeAsText = xmlSee.Value.Substring(startingIndex, endIndex - startingIndex);  //.Replace("<see cref=\"T:", "").Replace("\" />", "");
            System.Reflection.Assembly ThisAssembly = typeof(ThisProject.Controllers.HomeController).Assembly;
            tp = ThisAssembly.GetType(@typeAsText);
            if (tp == null)//try another referenced project
            {
                System.Reflection.Assembly externalAssembly = typeof(MyExternalReferncedProject.AnyClassInIt).Assembly;
                tp = externalAssembly.GetType(@typeAsText);
            }  
            
            if (tp == null)//also another referenced project- as needed
            {
                System.Reflection.Assembly anotherExtAssembly = typeof(MyExternalReferncedProject2.AnyClassInIt).Assembly;
                tp = anotherExtAssembly .GetType(@typeAsText);
            }
            if (@tp != null)
            {
                ModelDescription md = modelDescriptionGenerator.GetOrCreateModelDescription(tp);
                    @Html.DisplayFor(m => md.ModelType, "ModelDescriptionLink", new { modelDescription = md })            
            }
            else
            {            
                    @MvcHtmlString.Create(@typeAsText)            
            }
            index = xmlSee.Index + xmlSee.Length;
            xmlSee = xmlSee.NextMatch();
        }    
                @MvcHtmlString.Create(@xml.Substring(@index, @xml.Length - @index))    
    }
    else
    {    
            @MvcHtmlString.Create(@xml);    
    }
  
