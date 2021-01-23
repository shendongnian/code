    private void UpdateTotalBill()
    {
        decimal vat = 0;
        decimal TotalPrice = 0;
        long TotalProducts = 0;
        foreach (DataListItem item in dlCartProducts.Items)
        {
            Label PriceLabel = item.FindControl("lblPrice") as Label; // get price 
            TextBox ProductQuantity = item.FindControl("txtProductQuantity") as TextBox; // get quantity
        
		    Int64 priceLabel, productQuantity;
		    bool conversionResult = Int64.TryParse(PriceLabel.Text, out priceLabel);
		    if(!conversionResult) continue;
		    conversionResult = Int64.TryParse(ProductQuantity.Text, out productQuantity);
		    if(!conversionResult) continue;
		    decimal ProductPrice = priceLabel * productQuantity; //computation fro product price. price * quantity
            vat = (TotalPrice + ProductPrice) * 0.12M; // computation for vat
            vat = Math.Round(vat, 2);
            TotalPrice = TotalPrice + ProductPrice;
            TotalProducts = TotalProducts + productQuantity;
        }
        Label1.Text =Convert.ToString(vat);
        txtTotalPrice.Text = Convert.ToString(TotalPrice + 40.0M + vat); // add vat + 40 delivery charge to total price
        txtTotalProducts.Text = Convert.ToString(TotalProducts);
    }
