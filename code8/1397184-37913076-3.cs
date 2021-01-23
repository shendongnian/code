    <table>
        <tr>
            <th></th>
        </tr>
        @foreach (var item in Model)
        {
            <tr>
                <td> item.StudentName </td>
                <td>
                    @Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }) |
                    @Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }) |
                    @Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ })
                </td>
            </tr>
        }
    </table>
