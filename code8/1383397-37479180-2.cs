    @if (item.IsActive == 1) 
    {
        @Html.ActionLink("Edit", "Edit", new { id = item.ID })
    }
    else
    {
        <span>The option to edit locked.</span>
    }
