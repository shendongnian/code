    @model project_name.Models.ProductStatisticsList
    @{
     }
      @using (Html.BeginForm("index", "Home", FormMethod.Post, new { id = "formIndex" }))
    {
        @Html.DropDownListFor(model => model.SelectedMonth, (IEnumerable<SelectListItem>)ViewBag.Months, "Month") 
 
        <table class="table">
            @if (Model.Products != null)
            {
                for (var i = 0; i < Model.Products.Count; i++)
                {
                <tr>
                    <td>
                        @Html.DisplayFor(modelItem => Model.Products[i].Product_ID)
                        @Html.HiddenFor(modelItem => Model.Products[i].Product_ID)
                    </td>
                    <td>
                        @Html.DisplayFor(modelItem => Model.Products[i].ProductName)
                        @Html.HiddenFor(modelItem => Model.Products[i].ProductName)
                    </td>
                </tr>
                }
            }
        </table>
        <input type="submit" value="submit" />
    }
