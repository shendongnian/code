    public static List<Item> Search(List<Item> items, Predicate<Item> predicate)
    {
      var searchResults = items.Where(predicate).ToList();
      return searchResults.Any() ? searchResults : null;
    }
    
    // Keyword filter
    var keyword = request.Keyword;
    if (!string.IsNullOrWhiteSpace(keyword))
    {    
        _items = 
    	  Search(_items, x => x.Name.Contains(keyword)) ??
    	  Search(_items, x => x.Number == keyword) ??
    	  Search(_items, x => x.Code == keyword) ??
          new List<Item>();
    }
