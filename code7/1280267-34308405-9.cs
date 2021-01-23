    @model MVC_1.Models.ListNames
    @{
        ViewBag.Title = "ListNames";
    }
    <h2>ListNames</h2>
    <p>@ViewBag.Name</p>
    foreach(var name in Model.names)
    {
       <p>@name</p>
    }
