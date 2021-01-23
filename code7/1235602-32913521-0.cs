    @using (Html.BeginForm("Save", "Review", FormMethod.Post))
    {
        for (var i = 0; i < Model.Count; i++)
        {
            @Html.EditorFor(m => Model[i], "MyTemplateName");
        }
    }
