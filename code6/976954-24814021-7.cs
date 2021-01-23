    @model MvcApplication1.Models.BigViewModel
    
    @using (Html.BeginForm())
    {
        @Html.EditorFor(x => x.Confirm)
    
        {
            Html.RenderPartial("_Options");
            Html.RenderPartial("_Submit");
        }
    }
