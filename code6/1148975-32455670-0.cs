    <table class="table table-bordered">
    @foreach (string LoopHeader in ViewBag.Columns)
    {
        <th>@LoopHeader</th>
    }
    @foreach (var row in Model)
    {
        <tr>
            @foreach (var column in row)
            {
                <td>
                @((column.Key == "SapStoreID" || column.Key == "StoreName") ?     column.Value : Html.ActionLink((string)column.Value.ToString(), "Edit",     "StoreDepartment", new { PseudoKey = row.SapStoreID + "_" + column.Key }, ""))
                </td>
                }
    </tr>
    }
    </table>
