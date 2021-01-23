    public decimal GetTotalShoppingCart(int userID, string siteName)
    {
        decimal totalPrice=0;
        ShoppingCartInfo cartInfo = GetShopCard(userID, siteName);
        int siteID = GetSite(siteName);
        if (cartInfo != null)
        {
            DataSet cartItems = ShoppingCartItemInfoProvider.GetShoppingCartItems(cartInfo.ShoppingCartID);
        if (cartItems.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow row in cartItems.Tables[0].Rows)
            {
                totalPrice += decimal.Parse(row["SKUUnits"].ToString()) * decimal.Parse(row["SKUPrice"].ToString());//(decimal)ShoppingCartItemInfoProvider.GetShoppingCartItemInfo(int.Parse(row["CartItemID"].ToString())).TotalPrice;   
            }
        }
    }
    return totalPrice;
    }
