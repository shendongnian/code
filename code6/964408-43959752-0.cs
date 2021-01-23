       @Html.Grid(Model).Columns(columns =>
        {
                columns.Add(o => o.Customer.IsVip).Titled("Vip customer")
                columns.Add()
                .Titled(Translations.Global.FIRST_NAME)
                .SetWidth(110)
                .Encoded(false)
                .RenderValueAs(o => 
        
                    @if (o.LastName == 'Me')
                    {
                        <span class="label label-success">Active</span>
                    }
                    else
                    {
                        <span class="label label-important">Banned</span>
                    }
        )
        .Sortable(true);
        })
