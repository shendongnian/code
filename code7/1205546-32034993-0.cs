    @{
       var listItems = new List<SelectListItem>();
       listItems.Add(new SelectListItem
       {
          Text = "Item 1",
          Value = "Item 1"
       });
       listItems.Add(new SelectListItem
       {
          Text = "Item 2",
          Value = "Item 2",
          Selected = true
       });
    }
    
    @Html.DropDownListFor(model => model.MyValue, listItems, "-- Please choose --")
