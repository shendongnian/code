    public static string GetCartId()
    {
        var context = HttpContext.Current;
        if(context == null) return null;
        string cartId = "";
        var stringId = context.Session.GetString("cart");
        if(stringId == null)
        {
            cartId = Guid.NewGuid().ToString();
            stringId = cartId;
        }
        else if(stringId != null)
        {
            cartId = stringId;
        }
        return cartId;
    }
