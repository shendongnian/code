    private bool IsCompletelyEmpty(TextBox item, TextBox product, TextBox quantity) 
    {
      // To do: check that quantity is numeric, positive, item code is valid, etc.
      return String.IsNullOrEmpty(item.Text) && String.IsNullOrEmpty(product.Text) && String.IsNullOrEmpty(quantity.Text);
    }
    private bool IsCompletelyFilled(TextBox item, TextBox product, TextBox quantity) 
    {
      return !String.IsNullOrEmpty(item.Text) && !String.IsNullOrEmpty(product.Text) && !String.IsNullOrEmpty(quantity.Text);
    }
    private bool IsValidFilledOrEmpty(TextBox item, TextBox product, TextBox quantity) 
    {
      return IsCompletelyFilled(item, product, quantity) || IsCompletelyEmpty(item, product, quantity)
    }
