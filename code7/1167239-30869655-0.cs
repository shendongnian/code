    @model allegrotest.Models.SearchArrayModel
    @{
        ViewBag.Title = "ShowItems";
    }
    @using (Html.BeginForm())
    {
       @foreach (var item in Model.AttribArray)
       {
          <h2>@item.AttribName</h2>
          foreach (var item2 in item.AttribValues)
          {
             <h3>@item2</h3>
          }
       }
    }
