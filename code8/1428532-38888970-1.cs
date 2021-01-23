    var validEvents = new List<Item>();
    var allEvents = ((LinkField)this.controlItem.Fields["Event Container"]).TargetItem.Children.ToList(); // getting the events
    
    if (this.ddlMonths.SelectedIndex != 0 || this.ddlCategories.SelectedIndex != 0 || this.searchQuery.Text != string.Empty)
    {
        foreach (var currentEvent in allEvents)
        {
            var isValid = true;
    
            // 1. Check for months
            if (this.ddlMonths.SelectedIndex != 0)
            {
                // .. validation if event should be displayed
    
                if (!(isValid && startDate <= monthDates[1].Date && endDate >= monthDates[0].Date))
                {
                    isValid = false;
                }
            }
    
            // 2. Check for categories
            if (this.ddlCategories.SelectedIndex != 0)
            {
                foreach (var eventCategory in ((MultilistField) currentEvent.Fields["Categories"]).GetItems())
                {
                    if (!(isValid && eventCategory["Category"].ToLower() == this.ddlCategories.SelectedValue.ToLower()))
                    {
                        isValid = false;
                    }
                }
            }
    
            // 3. Check for search query
            if (this.searchQuery.Text != string.Empty)
            {
                var searchText = this.searchQuery.Text;
    
                if (!(isValid && currentEvent["Title"].Contains(searchText) || currentEvent["Text"].Contains(searchText)))
                {
                    isValid = true;
                }
            }
    
            if (isValid)
            {
                validEvents.Add(currentEvent);
            }
        }
    }
