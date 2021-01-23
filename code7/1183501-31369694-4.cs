    int totalPrice, totalProducts;
    bool totalPriceConversionResult = int.TryParse(txtTotalPrice.Text, out totalPrice), totalProductsConversionResult = int.TryParse(txtTotalProducts.Text, out totalProducts);
    
    
    ShoppingCart k = new ShoppingCart()
    {
        CustomerName = txtCustomerName.Text,
        CustomerEmailID = txtCustomerEmailID.Text,
        CustomerAddress = txtCustomerAddress.Text,
        CustomerPhoneNo = txtCustomerPhoneNo.Text,
        TotalProducts = totalProductsConversionResult ? totalProducts : 0,
        TotalPrice = totalPriceConversionResult ? totalPrice : 0,
        ProductList = productids,
        PaymentMethod = rblPaymentMethod.SelectedItem.Text
    
    };
