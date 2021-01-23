        @{
           var Acciones = new SelectList(new[]
           {
          new SelectListItem { Text = "Modificar", Value = 
           Url.Action("Edit", "Countries")},
          new SelectListItem { Text = "Detallar", Value = 
          Url.Action("Details", "Countries") },
          new SelectListItem { Text = "Eliminar", Value = 
          Url.Action("Delete", "Countries") },
         }, "Value", "Text");
        }
    
