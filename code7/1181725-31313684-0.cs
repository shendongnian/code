    GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
    int quantity;
    string sQuantity = ((TextBox)row.FindControl("txtQuantity")).Text;
    if(int.TryParse(sQuantity, out quantity))
    {
        ShoppingCart.Instance.SetItemQuantity(productId, quantity);
    }
    else
    {
        // do whatever you want if the textbox doesnt contains an int
        // for example:
        ShoppingCart.Instance.SetItemQuantity(productId, 0);
    }
