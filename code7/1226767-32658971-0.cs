    int categoryIdIndex = 7;
    int productIdIndex = 3;
    int quantityRequestedIndex = 5;
    
    List<string> errors = new List<string>()
    for (int index = 0; index < this.gridagree.Rows.Count; index++)
    {
      Row row = gridagree.Rows[index];
      int categoryId = Convert.ToInt32(row.Cells[categoryIdIndex].Text);
      int productId = Convert.ToInt32(row.Cells[productIdIndex].Text);
      int quantityRequested = Convert.ToInt32(row.Cells[quantityRequestedIndex].Text);
      int availableQuantity = s.getprodqun(productId);
      
      if(quantityRequested > availableQuantity)
      {
        errors.Add(string.Format("Inventory contains insufficient items for product id {0} ", productId));
      }
    }
    
    if(errors.Count == 0)
    {
      ... process the orders ...
    }
    else
    {
      ... show the errors
    }
