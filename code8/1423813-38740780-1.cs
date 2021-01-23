    @{
       foreach (var item in Model)
            {
    
                string RowColor = "Standard";
                string RowClassName = "row-" + item.CaseID;
                int StatusDays = int.Parse(item.StatusDays);
    
                if (item.Viewings == 0 && StatusDays >= 14)
                {
                    RowColor = "Red";
                }
    
    
            <tr class="row-click @RowClassName @RowColor" data-url="/Case/Details/@item.CaseID/">
                <td>
                    Html.DisplayFor(modelItem => item.CaseID)
                </td>
                <td>
                    item.RegistrationDate.Date.ToString("dd-MMM-yyyy")
                </td>
            </tr>
           }
    }
