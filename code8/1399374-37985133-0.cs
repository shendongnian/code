    int itemQuantity, itemPrice, itemTotal;
    
    if (Int32.TryParse(txtQty.Text, out itemQuantity) && Int32.TryParse(txtitemPrice.Text, out itemPrice))
    {
        if (ddlOption.SelectedItem.Value == "0")
        {
           itemTotal=itemQuantity * itemPrice + 10;
           txtPrice.Text=itemTotal.ToString();
        }
        else if (ddlOption.SelectedItem.Value == "1")
        {
           itemTotal=itemQuantity * itemPrice + 20;
           txtPrice.Text=itemTotal.ToString();
        }
    }
  
