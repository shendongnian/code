    protected void btnAdd_Click(object sender, EventArgs e)
    {
        //Change ProductID, Quantity, Available, Criticallevel to actual values
        if (!IsCritical(ProductID, Quantity, Available, Criticallevel))
    	{
    		Response.Redirect("~/Account/AddToCart.aspx?ID=" + 
    		Request.QueryString["ID"].ToString() + 
    		"&qty=" + txtQty.Text);
    	}
    	else
    	{
    		//Write error message here
    	}
    }
