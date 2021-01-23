    @Html.Grid(Model)..Columns(columns =>
    {
            columns.Add(o => o.Customer.IsVip)
                    .Titled("Vip customer")
    columns.Add(x=>x.FirstName)
    .Titled(Translations.Global.FIRST_NAME)
    .SetWidth(110)
    .RenderValueAs(o => CustomRenderingOfColumn(o))
    .Sortable(true);
    })
