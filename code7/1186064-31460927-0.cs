    public List<CartItem> PostAllCartItemsFromArbitraryJson(string jsonStr)
    {
        List<CartItem> AllCartItems = new List<CartItem>();
        try
        {
            dynamic BaseJson = JObject.Parse(jsonStr.ToLower());
            CheckForCarts(AllCartItems, BaseJson);
        }
        catch (Exception Error)
        {
        }
        return AllCartItems;
    }
    private void CheckForCarts(List<CartItem> AllCartItems, dynamic BaseJson)
    {
        foreach (dynamic InnerJson in BaseJson)
        {
            if (InnerJson.Name == "cartitems")
            {//Assuming this is an [] of cart items
                foreach (dynamic NextCart in InnerJson.Value)
                {
                    try
                    {
                        CartItem FoundCart = new CartItem();
                        FoundCart.Id = NextCart.id;
                        FoundCart.Qty = NextCart.qty;
                        AllCartItems.Add(FoundCart);
                    }
                    catch (Exception Error)
                    {
                    }
                }
            }
            else if (InnerJson.Value is JObject)
            {
                CheckForCarts(AllCartItems, InnerJson.Value);
            }
        }
    }
    public class CartItem
    {
        public int Id;
        public int Qty;
    }
