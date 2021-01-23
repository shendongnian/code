    private void RemoveHighLightCartProducts( string ProductId)
    {
     
        if (Session["MyCart"] != null)
        {
            DataTable dtProductsAddedToCart = (DataTable)Session["MyCart"];
           //delete row which contains product data.
        var ProductRowToBeDeleted=dtProductsAddedToCart.Select("ProductID ="+ProductID);
        foreach(var row in ProductRowToBeDeleted)
        {
        row.delete();
        }
                foreach (DataListItem item in dlProducts.Items)
                {                  
                    
                        Button btnAddToCart = item.FindControl("btnAddToCart") as Button; 
                        btnAddToCart.BackColor = System.Drawing.Color.Red;
                        btnAddToCart.ForeColor = System.Drawing.Color.White;
                        btnAddToCart.Text = "Add to Cart";
                        Image imgGreenstar = item.FindControl("imgStar") as Image;
                        imgGreenstar.Visible = false;
                    }
        }
     }
