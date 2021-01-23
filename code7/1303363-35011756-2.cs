    class AutoCompleteItem {
        String Text {get; set;}
        Item Item {get; set;}
    }
    var firstNames = dbContext.Items.Select(p => new AutoCompleteItem { Name = p.Client.Contract.FirstName, Item = p})
    var lastNames =  dbContext.Items.Select(p => new AutoCompleteItem { Name = p.Client.Contract.SurName, Item = p})
    var result = firstName.Union(lastNames).Where(p => p.Name.Contains(searchText)).OrderBy(a => a.Item.IeUtem);
   
