     @{
            int counter = 0;
            foreach (var item in Model)
            {
                counter++;
                if (counter > 1 && counter < 6)
                {
                    <tr>
                        <td>
                            @Html.DisplayFor(modelItem => item.Category.Title)
                        </td>
                        <td>
                            @Html.DisplayFor(modelItem => item.Survey.Title)
                        </td>
                        <td>
                            @Html.DisplayFor(modelItem => item.Title)
                        </td>
                    </tr>
                }
            }
        }
