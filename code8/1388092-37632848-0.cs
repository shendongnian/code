    @model testproject.Models.ViewModels.TestViewModel
    @{
        ViewBag.Title = "Index";
    }
    
    @using (Html.BeginForm())
    {
        <div>@Html.DisplayFor(m=>m.testee)</div>
    }
