    var items = (from m in db.Model1s
                 select new SelectListItem{
                     Value = m.Id,
                     Text = m.Name
                 }); // This is where you bind your Model1 to the dropdownlist
    // Add a default id-name pair as needed.
    YourViewModel.Model1Items = new SelectList(items.ToList(), "Value", "Text");
