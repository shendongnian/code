    // itemsQuery will be of type IQueryable or IEnumerable depending on type of Items
    var itemsQuery = model.Items.Where(x => x.Id > 0);
    
    if (SortBy == "Description")
    {
      // we'll chain additional criteria or sorts to the IQueryable,
      // and update the query reference by assigning over the previous itemsQuery variable
      if (Direction == "Descending")
        itemsQuery  = itemsQuery.OrderByDescending(x => x.Description);
      else
        itemsQuery  = itemsQuery.OrderBy(x => x.Description);
    }
    
    // I want to jump to the second page
    this.Items = itemsQuery.Skip(26).ToList();
