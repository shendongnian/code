    @model project_name.Models.ProductStatisticsList
    @{
     }
    @using (Html.BeginForm("index", "Home", FormMethod.Post, new { id = "formIndex" }))
    {
       @Html.DropDownListFor(model => model.SelectedMonth, (IEnumerable<SelectListItem>)ViewBag.Months, "Month") 
       <input type="submit"  value="submit"/>
    }
    <table class="table">
   
      @if (Model.Products != null)
      {
         foreach (var item in Model.Products)
         {
            <tr>
                <td>
                    @Html.DisplayFor(modelItem => item.Product_ID)
                </td> 
                <td>
                    @Html.DisplayFor(modelItem => item.ProductName)
                </td>           
           </tr>
        }
    }     
    </table>
