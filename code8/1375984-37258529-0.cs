    public decimal GetTotalShoppingCart(int userID, string siteName)
    {
        decimal totalPrice = 0;
        ShoppingCartInfo cartInfo = GetShopCard(userID, siteName);
        // Not sure what siteID is used for here...
        int siteID = GetSite(siteName);
        if (cartInfo != null)
        {
            DataSet cartItems = ShoppingCartItemInfoProvider.GetShoppingCartItems(cartInfo.ShoppingCartID);
            // Sorry if this is confusing. It's LinQ.
            totalPrice += cartItems.Tables[0].Rows
                .Sum(s => (decimal)ShoppingCartItemInfoProvider.GetShoppingCartItemInfo(int.Parse(s["CartItemID"].ToString())).TotalPrice)
        }
        return totalPrice;
    }
