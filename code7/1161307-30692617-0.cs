    public async Task InsertAsync()
    {
        Product product = new Product
        { 
           name = NPDName.Text,
           description = NPDDescription.Text,
           price = NPDPriceExkl.Text,
           tax = NPDTax.Text,
           stock = NPDStock.Text,
           available = NPDCBAvailable.Checked,
           active = true
        };
        await productTable.InsertAsync(product);
    }
