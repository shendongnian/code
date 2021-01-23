    public decimal GetTotalShoppingCart(int userID, string siteName)
    {
        decimal totalPrice = 0;
        ShoppingCartInfo cartInfo = GetShopCard(userID, siteName);
        // Not sure what siteID is used for here...
        int siteID = GetSite(siteName);
        if (cartInfo != null)
        {
            if (cartItems.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in cartItems.Tables[0].Rows)
                {
                    totalPrice += (decimal)ShoppingCartItemInfoProvider.GetShoppingCartItemInfo(int.Parse(row["CartItemID"].ToString())).TotalPrice;   
                }
            }
        }
        return totalPrice;
    }
