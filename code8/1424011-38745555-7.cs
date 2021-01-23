    @model MVC.Models.AModel
    @if (Model == null)
    {
        <span>Model saved</span>
    }
    else
    {
        using (Html.BeginForm("Save", "Home", FormMethod.Post))
        {
            Html.RenderPartial("Partials/CModel", Model.CModel, new ViewDataDictionary { TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "CModel" } });
            <hr />
            Html.RenderPartial("Partials/BModel", Model.BModel, new ViewDataDictionary { TemplateInfo = new TemplateInfo { HtmlFieldPrefix = "BModel" } });
            <input type="submit" name="PostType" value="Add"/><br />
            <input type="submit" name="PostType" value="Save"/>
        }
    }
