    @if (Model.Categories.Count > 0)
    {
         <table>
              foreach (WarehouseCategoryModel categoryModel in Model.Categories)
              {
                   <tr>
                        <td>@Html.ActionLink(categoryModel.Name, "Category", "-WarehouseCatalog", new { ide = categoryModel.ID }, null)</td>
                        @if(categoryModel.Count > 0)
                        {
                             <td>@categoryModel.Count</td>
                        }
                        else
                        {
                             <td>&nbsp;</td>
                        }
                   </tr>
              }
         </table>
    }
