    public string GetCartId(HttpContextBase context )
    {
        // You'd probably better return null here.
        if (context.Request.Cookies["CartId"] == null) return null;
        string CartId = context.Request.Cookies["CartId"].Value;
        if (String.IsNullOrEmpty(CartId))
        {
            CartId = Guid.NewGuid().ToString();
            HttpCookie cookie = new HttpCookie("CartId", CartId);
            cookie.Expires = DateTime.Now.AddDays(1);
            context.Response.Cookies.Add(cookie);
        }
        return CartId;   
    }
