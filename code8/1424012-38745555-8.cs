    @model MVC.Models.BModel
    @{
        for (var i = 0; i < Model.DModels.Count(); i++)
        {
            Html.RenderPartial("Partials/DModel", Model.DModels[i], new ViewDataDictionary { TemplateInfo = new TemplateInfo { HtmlFieldPrefix = $"{ViewData.TemplateInfo.HtmlFieldPrefix}.DModels[{i}]" } });
        }
    }
