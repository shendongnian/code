    @foreach (var item in ViewBag.Cities)
    {
        <h2>@item.Name</h2>
        <p>@Html.Raw(@item.Shorttext)</p>
        <p>@item.GeoCoordinates.Longitude</p>
        <p>@item.GeoCoordinates.Longitude</p>
        @foreach (var image in item.Images)
        {
            <img src=@image>
        }
    }
