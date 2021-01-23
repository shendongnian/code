    if (!String.IsNullOrEmpty(searchCategory)) {
        // Equals ensure value comparison instead of possible reference
        profiles = profiles.Where(x => x.Categories.Any(y => y.Name.Equals(searchCategory));
        DropDownValues = new List<SelectListItem>();
    
        // iterate through category list and pass values to SelectListItem
        foreach (Categories cat in profiles) {
            DropDownValues.Add(new SelectListItem() { Text = cat.Name, Value = cat.Value });
        }
    }
