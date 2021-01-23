    public PartialViewResult Search(string itemName, string itemText)
    {
      var items = ??
      // filter the data (adjust to suit your needs)
      if (itemName != null)
      {
        items = items.Where(x => x.ItemName.ToUpperInveriant().Contains(itemName.ToUpperInveriant()) 
      }
      if (itemText != null)
      {
        items = items.Where(x => x.ItemDescription.ToUpperInveriant().Contains(itemText.ToUpperInveriant()) 
      }
      // query you data
        return PartialView("_Search", items); 
    }
