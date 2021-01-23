    @for (int i = 0; i < Model.AllDataObjects.Count; i++)
    {
        <tr>
            <td>@Html.DisplayFor(m => m.AllDataObjects[i].Name)</td>
            <td>@Html.DisplayFor(m => m.AllDataObjects[i].Data)</td>
            <td>
                @Html.HiddenFor(m => m.AllDataObjects[i].ObjectId)
                @if (Model.AllDataObjects[i].Rule.Contains("Yes;No"))
                {
                    @Html.DropDownListFor(m => m.AllDataObjects[i].Value, new SelectList(new string[]{ "Yes", "No" }));
                }
                else
                {
                    @Html.TextAreaFor(m => m.AllDataObjects[i].Value, new { style = "width: 400px;", @rows = 5 })
                }
            </td>
        </tr>
    }
