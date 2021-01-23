    @model Project.Web.Models.AModel
    @using (Html.BeginForm())
    {
        @Html.AntiForgeryToken()
        @{ Html.RenderPartial("CreateB",Model.BModel, new ViewDataDictionary { TemplateInfo = new System.Web.Mvc.TemplateInfo { HtmlFieldPrefix = "BModel" } }) }
        @{ Html.RenderPartial("CreateC",Model.CModel, new ViewDataDictionary { TemplateInfo = new System.Web.Mvc.TemplateInfo { HtmlFieldPrefix = "CModel" } }) 
        <input style="border-radius:4px;width:100px;" type="button" value="next" id="next" class="btn btn-default" />
    }
