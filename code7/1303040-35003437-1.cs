    if (String.Equals(e.CommandName, "AddToCart"))
    {
      
      ListViewDataItem dataItem = (ListViewDataItem)e.Item;
      string pID = 
        lvCatalog.DataKeys[dataItem.DisplayIndex].Value.ToString();
      
      AddItemToCart(e.CommandArgument.ToString())
      // or 
      AddItemToCart(pID);
      }
    }
  }
