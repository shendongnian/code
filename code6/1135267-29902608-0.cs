    List<SelectListItem> items = new List<SelectListItem>();
    while( dr.Read() ) {
        
        SelectListItem li = new SelectListItem() {
            Text = dr.GetString("NAME"),
            Value = dr.GetString("CODE")
        };
        items.Add( li );
    }
    ViewData["ListItems"] = items;
////
    @Html.DropDownListFor( m => m.LOBTypes, this.ViewData["ListItems"] );
