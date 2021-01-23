    @model IEnumerable<MvcMovie2.Models.Movie>
    
    @{
        ViewBag.Title = "Index";
    }
    
    <h2>Index</h2>
    
    <p>
        @Html.ActionLink("Create New", "Create")
    </p>
    <table class="table">
        @Html.Partial("Header")
        @foreach (var item in Model) 
        {
            @Html.Partial("Movie", item)
        }
    </table>
