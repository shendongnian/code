    @model WebApplication_Test.Models.CaseViewModel
    
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
              @Html.DropDownListFor(
                   m => m.AppId,
                   new SelectList(Model.Apps, "Id", "Name", Model.AppId),
                   "-- Select --"
              )
              @Html.ValidationMessageFor(m => m.AppId)
         </div>
         <div>
              <button type="submit">Submit</button>
         </div>
    }
