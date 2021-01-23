    @{ var list = Model.ToList();
    for (int i = 0; i < list.Count; i++)
        {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => list[i].Category.Title)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => list[i].Survey.Title)
                </td>
                <td>
                    @Html.DisplayFor(modelItem => list[i].Title)
                </td>       
            </tr>
        }
     }
