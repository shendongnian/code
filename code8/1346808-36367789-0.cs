    @(Html.Kendo().Grid(Model.Items)
            .Name("items")
            .Columns(columns => 
            {
                columns.Bound(a => a.ItemId);
                columns.Bound(a => a.ItemName);
                columns.Bound(a => a.Price);
                columns.Bound(a => a.Quantity);
            })
            .ToolBar(toolBar =>
            {
                toolBar.Save().SaveText("Send").CancelText("Cancel");
            })
            .Editable(editable => editable.Mode(GridEditMode.InCell))
            .Scrollable()
            .Pageable(pageable => pageable
                .ButtonCount(5)
            )
            .HtmlAttributes(new { style = "height:550px;" })
            .DataSource(datasource => datasource
                .Ajax()
                .Batch(true)
                .PageSize(30)
                .ServerOperation(false)
                .Model(model =>
                {
                    model.Id(a => a.ItemId);
                    model.Field(a => a.Name).Editable(false);
                    model.Field(a => a.Price).Editable(false);
                    model.Field(a => a.Quantity);
                })
                .Update(update => update.Action("SendOrder","Orders").Data("getAdditionalData"))
            )
        )
    function getAdditionalData() {
        
        var cat = $("#categories").val();
        var cli = $("#client").val();
        return {
            clientId: cli,
            categoryId: cat
        }
    }
