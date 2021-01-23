    //Add this to HighLightCartProducts() method	
    else//  ! (dtProductsAddedToCart.AsEnumerable().Any(row => hfProductID.Value == row.Field<String>("ProductID")))
                        {
                        Button btnAddToCart = item.FindControl("btnAddToCart") as Button; 
                        btnAddToCart.BackColor = System.Drawing.Color.Red;
                        btnAddToCart.ForeColor = System.Drawing.Color.White;
                        btnAddToCart.Text = "Add to Cart";
                        Image imgGreenstar = item.FindControl("imgStar") as Image;
                        imgGreenstar.Visible = False;
