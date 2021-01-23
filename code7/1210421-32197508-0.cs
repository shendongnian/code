        Html.X().Store().ID("store1")
            .PageSize(20)
            .DataSource(Model)
            .Model
            (
                Html.X().Model()
                .Fields
                (
                    new ModelField("company", ModelFieldType.String),
                    new ModelField("price", ModelFieldType.Float)
                )
            )
            .ServerProxy
            (
                Html.X().AjaxProxy()
                .Url(Url.Action("GetDataFromSQL"))
                .Timeout(120000)
            )
