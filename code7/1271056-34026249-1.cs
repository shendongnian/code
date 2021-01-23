    if (lstCheckoutProduct.IsFocused)
    {
      int productIndex = lstCheckoutProduct.SelectedIndex;
      lstCheckoutProduct.Items.Remove(lstCheckoutProduct.SelectedItem);
      lstCheckoutPrice.Items.RemoveAt(productIndex);
    }
    else
    {
      int priceIndex = lstCheckoutPrice.SelectedIndex;
      lstCheckoutPrice.Items.Remove(lstCheckoutPrice.SelectedItem);
      lstCheckoutProduct.Items.RemoveAt(priceIndex);
    }
