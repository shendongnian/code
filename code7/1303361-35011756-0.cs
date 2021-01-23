    dbContext.Items   
        .Where(
         p =>
    .Client.Contact != null && p.Client.Contact.Firstname.ToLower().Contains(searchText.ToLower()))
  
         || /*etc*/ )
         .Select(p => new MatchedItem { Item = p, Firstname = p.Client.Contact.Firstname.ToLower().Contains(searchText.ToLower()) });
