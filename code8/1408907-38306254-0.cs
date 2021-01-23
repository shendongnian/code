    @model List<Vidly.Models.Movie>
    @{
        ViewBag.Title = "All Movies";
        Layout = "~/Views/Shared/_Layout.cshtml";
    }
    <h2>AllMovies</h2>
    <ul>
        @foreach (var movie in Model)
        {
            <li>@movie.Name</li>
        }
    </ul>
