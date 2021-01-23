    @{
       List<SelectListItem> listItems= new List<SelectListItem>();
       listItems.Add(new SelectListItem{Text = "Patient list", Value = "Patient list"});
       listItems.Add(new SelectListItem{Text = "Benchmarking", Value = "Benchmarking"});
       listItems.Add(new SelectListItem{Text = "Center Specific",Value = "Center Specific"});
       listItems.Add(new SelectListItem{Text = "ECMO Run",Value = "ECMO Run"});
    }
    
    @Html.DropDownListFor(model => model.MySelectedItem, listItems, "-- Select --")
