    @model Project.Models.ViewModel
    
    @using (Html.BeginForm())
    {
         @Html.TextBoxFor(m => m.Name)
    
         <button type="submit">Submit</button>
    
         if (!string.IsNullOrWhiteSpace(Model.Name))
         {
              <p>welcome, your name is @Model.Name</p>
         }
    }
