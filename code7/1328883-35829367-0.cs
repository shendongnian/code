    protected void btnCheckout_Click(object sender, EventArgs e)
    {
        // by default we don't want to redirect so set the boolean
        // flag to false
        bool shouldRedirect = false;
    
        foreach (ListViewItem Items in lvCart.Items)
        {
            ...
            if (Quantity > Available)
            {
                ...
            }
            else
            {
                shouldRedirect = true;
            }
        }
    
        if (shouldRedirect)
        {
            Response.Redirect("/Users/Orders/SO/Default.aspx");
        }
    }
