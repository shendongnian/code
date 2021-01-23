      @{
        
          if(ViewBag.Listroles != null){
          foreach (var roles in ViewBag.Listroles)
            {
                <tr>
                    <td>@roles.RoleName</td>
                    <td>
                          @Html.ActionLink("Edit", "EditRoles", new { id=roles.RoleId }) |
                          @Html.ActionLink("Details", "Details", new { id=roles.RoleId }) |
                          @Html.ActionLink("Delete", "Delete", new { id=roles.RoleId })
                     </td>
                </tr>
            }
          
          }
          
        }
