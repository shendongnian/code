     @{
       foreach (var itm in Model.Locations[0].Positions)
       {
          <div>
              @Html.RadioButtonFor(m=>Model.Locations[0].SelectedPosition,itm.ID ,new { id = "ID_" + itm.ID })
              @Html.Label("Location" + itm.ID, itm.Type)
          </div>
       }
      }
