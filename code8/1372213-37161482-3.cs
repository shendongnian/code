    @model WebApplication_Test.Models.TestViewModel
    
    @using (Html.BeginForm())
    {
         <div>
              @Html.DropDownListFor(
                   m => m.StatusId,
                   new SelectList(Model.Statuses, "Id", "Name", Model.StatusId),
                   "-- Select --"
              )
              @Html.ValidationMessageFor(m => m.StatusId)
         </div>
         <div>
              <button type="submit">Submit</button>
         </div>
    }
