    @if (User.IsInRole("AddCOA"))
    {
        @Html.Actionlink("Edit", "Edit", "Controller", new { @class = "btn btn-success" })
    }
    else
    {
        @Html.Actionlink("Edit", "Edit", "Controller", new { @class = "btn btn-success disbled" })
    }
