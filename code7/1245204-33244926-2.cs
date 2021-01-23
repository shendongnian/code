        @grid.GetHtml(tableStyle: "table table-hover",
                          columns:
            grid.Columns
            (
                    grid.Column("Property1", "Property1", style: "Large"),
                    grid.Column("Property2", "Property2", style: "Small")
                    grid.Column("Action", format: @<text>
                        @Html.ActionLink("Edit", "Edit", new { id = item.Id})
                        | @Html.ActionLink("Delete", "Delete", new { id = item.Id })
                    </text>, style: "action", canSort: false)))
    <style type="text/css">
    .Large{
        width: 20%;
    }
    .Small{
        width: 5%;
    }
