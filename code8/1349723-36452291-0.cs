    grid.Column(format: (item) =>
    {
         if (!String.IsNullOrEmpty(item.ContactEmail))
         {
             return Html.Raw("<a href='mailto:@item.ContactEmail' target='_top'>Email</a>"));
         }
    })
        
