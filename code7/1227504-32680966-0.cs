    protected void lnkBtnReadyToServeAdd_Click(object sender, EventArgs e)
    {
        DataTable dtCart = (DataTable)Session["sessiondtCart"];
        foreach(DataRow row in dtCart.Rows)
        {
            if(row["ProductName"] == lblProductName.Text) //check if already exists
            {
                //now we know we need to increment the quantity, because it's already in the cart
                int quantity = row["TotalPrice"] / int.Parse(lblProductPrice.Text);
                row["TotalPrice"] = quantity + int.Parse(txtQuantity.Text);
            }
            else
            {
                //now we know the item wasn't in the cart, so we need to add it
                dtCart.Rows.Add(lblProductName.Text, lblProductPrice.Text, txtQuantity.Text, imgk1.ImageUrl, int.Parse(lblProductPrice.Text) * int.Parse(txtQuantity.Text));
            }
        }
        
        Session["sessiondtCart"] = dtCart;
    }
