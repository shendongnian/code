    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string productId;
        ArrayList arProduct = Session['Cart'] as ArrayList;
        if(arProduct == null)
        {
            arProduct = new ArrayList();
            Session['Cart'] = arProduct;
        }
        if (Request.QueryString.Get("ProductId") != null)
        {
            productId = Request.QueryString.Get("ProductId");
            arProduct.Add(productId);
        }
        Session["Cart"] = arProduct;
        Response.Redirect("Cart.aspx");
    }
