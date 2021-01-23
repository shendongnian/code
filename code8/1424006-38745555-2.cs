    @{
        for (var i = 0; i < Model.DModel.Count(); i++)
        {
            Html.RenderPartial("Name", Model.DModel[i], new ViewDataDictionary { TemplateInfo = new System.Web.Mvc.TemplateInfo { HtmlFieldPrefix = "DModel["+i+"]" } });
        }
    }
