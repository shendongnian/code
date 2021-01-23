    @{
        if (item.IsActive) 
          { @Html.ActionLink("Edit", "Edit", new { id = item.ID })  }
        else
          { <span>The option to edit locked.</span> }
     }
