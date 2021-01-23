    private MyProducts product;
    public MyProducts Product
    {
      set
      {
        product = value;
        if (product != null)
        {
          nameTextBox.Text = product.Name;
          quantityTextBox.Text = product.Quantity.ToString();
        }
    }
