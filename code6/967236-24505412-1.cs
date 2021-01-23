    @foreach (var item in modelOrdered) {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.SectorID)
                </td>
                .
                .
                .
                <td>
                    @Html.DisplayFor(modelItem => item.DateTime)
                </td>
                <td>
                    @Html.ActionLink("Details", "Details", new { id=item.ID }) |
                    @Html.ActionLink("Delete", "Delete", new { id=item.ID })
                </td>
            </tr>
        }
