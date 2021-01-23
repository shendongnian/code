    public void Validate(List<Product> products)
    {
        if (products == null || products.Length == 0)
        {
            MessageBox.Show("Too few products");
            return;
        }
        if (products.Length > 5)
        {
            MessageBox.Show("Too many products");
            return;
        }
        // do something useful with the products
    }
