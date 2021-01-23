    @model PagedList<Gästbok>
    @foreach (var item in Model)
    {
        <p>@Html.DisplayFor(modelItem => item.Kommentar)</p>
        <br />
        <p>
            Postad: @Html.DisplayFor(modelItem => item.Datum) 
            Av: @Html.DisplayFor(modelItem => item.Namn
            (@Html.DisplayFor(modelItem => item.Email))
        </p>
        <hr />
    }
    <p>
        @Html.PagedListPager(Model, page => Url.Action("Index",
            new { page, pageSize = Model.PageSize }))
         
        Showing @Model.FirstItemOnPage to @Model.LastItemOnPage
            of @Model.TotalItemCount comments.
    </p>
    <hr />
    <button class="btn btn-default">
        @Html.ActionLink("Skriv nytt inlägg", "Create")
    </button>
