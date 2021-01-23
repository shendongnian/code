    @model MAWGridModel<AktionGridRowModel>
    @if (Model != null)
    {
        @Html.DevExpress().GridView(settings =>
        {
            settings.Name = "MAWAktionenErgebnisGrid";
        ...
        }).Bind(Model).GetHtml();
    }
