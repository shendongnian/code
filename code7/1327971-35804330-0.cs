    long ProductPrice;
    try
    {
        // hey you never know, someone might just put in an int64 in that textbox!
        ProductPrice = Convert.ToInt32(PriceLabel.Text) * 
            Convert.ToInt32(ProductQuantity.Text);
    }
    catch
    {
        decimal tempPrice = Convert.ToDecimal(PriceLabel.Text) *
            Convert.ToDecimal(ProductQuantity.Text);
        ProductPrice = Convert.ToInt64(tempPrice);
    }
