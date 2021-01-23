    var oldList = new List<MyClass>();
    var newList = new List<MyClass>();
    // O(1) lookups vs O(N) lookups
    var oldListIds = new HashSet<int>(oldList.Select(x => x.Id));
    var newListIds new HashSet<int>(newList.Select(x => x.Id));
    
    //Search for items on the new list that are not present on the old one
    var addedItems = newList.Where(item => !oldListIds.Contains(item.Id));
    
    //Search for items on the old list that are not present on the new one
    var deletedItems = oldList.Where(item => !newListIds.Contains(item.Id));
    
    //Search for items present on both lists, but with any property changed
    var updatedItems = from x in oldList
                       join y in newList on x.Id equals y.Id
                       where x.Name != y.Name ||
                             x.Description != y.Description ||
                             x.Quantity != y.Quantity
                       select new { OriginalEntity = x, NewEntity = y };
    
    // Use .Any() instead of .Count() so we stop after first item
    bool anyChanges = addedItems.Any()   ||
                      deletedItems.Any() ||
                      updatedItems.Any();
