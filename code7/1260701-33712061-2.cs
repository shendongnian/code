    public string GetCartId(HttpContextBase context )
    {
        string cartId;
        if (context.Request.Cookies["CartId"] == null)
        {
            cartId = Guid.NewGuid().ToString();
            HttpCookie cookie = new HttpCookie("CartId", cartId);
            cookie.Expires = DateTime.Now.AddDays(1);
            context.Response.Cookies.Add(cookie);
        }
        else 
        {
            cartId = context.Request.Cookies["CartId"].Value;
        }
        return cartId;   
    }
