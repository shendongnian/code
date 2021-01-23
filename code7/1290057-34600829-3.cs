    @model Docent
    <h4>My Locations</h4>
    @foreach (var item in Model.Locaties)
    {
      @item.Name @Html.ActionLink("Delete", "DeleteLocaties", new { id = item.LocatieID })
    }
    
    <h4>My Competences</h4>
    @foreach (var item in Model.Competenties)
    {
      @item.Name @Html.ActionLink("Delete", "DeleteCompetenties", new { id = item.CompetentiesID })
    }
