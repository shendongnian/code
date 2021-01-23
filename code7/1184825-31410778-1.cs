    Model ......
    @{
       Layout=.....
       var adminMenu = Html.Partial("Admin");
    }
    @if (User.IsInRole("Admin"))
    {
       Html.Raw(adminMenu);
    }
