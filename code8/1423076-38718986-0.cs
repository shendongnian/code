     @model Dropdownlist.Models.Country
     @{
           ViewBag.Title = "Index";
       }
    
       <h2>Index</h2>
       @using (Html.BeginForm(FormMethod.Post))
       {
           <div>
               @Html.DropDownList("ID", new List<SelectListItem>
           {
               new SelectListItem{ Text = "India", Value = 1},
               new SelectListItem{ Text = "UK", Value = 2},
               new SelectListItem{ Text = "USA", Value = 2}
           }, "Select a Country",new { id="ddlCountry"})
           @Html.Hidden("CountryName")
           </div>
           <div>
               <input type="submit" value="Save" />
           </div>
       }
