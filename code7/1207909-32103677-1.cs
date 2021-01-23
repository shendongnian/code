    @model CarsViewModel
    
    @{
         ViewBag.Title = "Home Page";
     }
    
    <div style="align-content:center;">
    @using (Html.BeginForm())
    {
    <p>My Caseload:
      @Html.DropDownListFor(m=>m.SelectedCarId, Model.Cars )
      <input type="submit" value="Find" />
    </p>
    }
    </div>
