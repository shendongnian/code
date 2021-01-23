     protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        string ProductID = Convert.ToInt16((((Button)sender).CommandArgument)).ToString();
        string ProductQuantity = "1"; 
        DataListItem currentItem = (sender as Button).NamingContainer as DataListItem;
        Label lblAvailableStock = currentItem.FindControl("lblAvailableStock") as Label;
        if (Session["MyCart"] != null)
        {
            DataTable dt = (DataTable)Session["MyCart"];
            var checkProduct = dt.AsEnumerable().Where(r => r.Field<string>("ProductID") == ProductID); // check whether product is already added or not
            if (checkProduct.Count() == 0)
            {
                string query = "select * from Products where ProductID = " + ProductID + "";
                DataTable dtProducts = GetData(query);
                DataRow dr = dt.NewRow();
                dr["ProductID"] = ProductID;
                dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
                dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
                dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
                dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
                dr["ProductQuantity"] = ProductQuantity;
                dr["AvailableStock"] = lblAvailableStock.Text;
                dt.Rows.Add(dr);
                Session["MyCart"] = dt;
                btnIslandGas.Text = dt.Rows.Count.ToString();
				HighLightCartProducts();
            }
            else
            {
               RemoveHighLightCartProducts(ProductId);
            }
        }
        else
        {
            string query = "select * from Products where ProductID = " + ProductID + "";
            DataTable dtProducts = GetData(query);
            DataTable dt = new DataTable(); //storing all of the records
            dt.Columns.Add("ProductID", typeof(string)); // adding the columns
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Price", typeof(string));
            dt.Columns.Add("ImageUrl", typeof(string));
            dt.Columns.Add("ProductQuantity", typeof(string));
            dt.Columns.Add("AvailableStock", typeof(string));
            DataRow dr = dt.NewRow(); //adding the rows
            dr["ProductID"] = ProductID;
            dr["Name"] = Convert.ToString(dtProducts.Rows[0]["Name"]);
            dr["Description"] = Convert.ToString(dtProducts.Rows[0]["Description"]);
            dr["Price"] = Convert.ToString(dtProducts.Rows[0]["Price"]);
            dr["ImageUrl"] = Convert.ToString(dtProducts.Rows[0]["ImageUrl"]);
            dr["ProductQuantity"] = ProductQuantity;
            dr["AvailableStock"] = lblAvailableStock.Text;  
            dt.Rows.Add(dr); //adding the data row in the data table. 
            Session["MyCart"] = dt; //asigning the datatable in the session.
            btnIslandGas.Text = dt.Rows.Count.ToString();
			HighLightCartProducts();
        }
        
    }
    private void HighLightCartProducts()
    {
        if (Session["MyCart"] != null)
        {
            DataTable dtProductsAddedToCart = (DataTable)Session["MyCart"];
            if (dtProductsAddedToCart.Rows.Count > 0)
            {
                foreach (DataListItem item in dlProducts.Items)
                {
                    HiddenField hfProductID = item.FindControl("hfProductID") as HiddenField; // Getting hidden filed value
                    if (dtProductsAddedToCart.AsEnumerable().Any(row => hfProductID.Value == row.Field<String>("ProductID")))
                    {
                        //item.BackColor =  System.Drawing.Color.Red;
                        Button btnAddToCart = item.FindControl("btnAddToCart") as Button; //item.FinControl finds the item(Button)
                        btnAddToCart.BackColor = System.Drawing.Color.Blue;
                        btnAddToCart.ForeColor = System.Drawing.Color.White;
                        btnAddToCart.Text = "Added to Cart";
                        Image imgGreenstar = item.FindControl("imgStar") as Image;
                        imgGreenstar.Visible = true;
                    }                    
                }
            }
        }
    }
  
        private void RemoveHighLightCartProducts(string ProductId)
{
    if (Session["MyCart"] != null)
    {
        DataTable dtProductsAddedToCart = (DataTable)Session["MyCart"];
        //delete row which contains product data.
        var ProductRowToBeDeleted = dtProductsAddedToCart.Select("ProductID =" + ProductId);
        foreach (var row in ProductRowToBeDeleted)
        {
            row.Delete();
        }
        foreach (DataListItem item in dlProducts.Items)
        {
		 //if (dtProductsAddedToCart.AsEnumerable().Any(row => ProductID!=row.Field<String>("ProductID")))
		 foreach((DataRow rw in dtProductsAddedToCart.Rows)
		 {
			if(rw["ProductID"])!=ProductID)
			{
				Button btnAddToCart = item.FindControl("btnAddToCart") as Button; //item.FinControl finds the item(Button)
                btnAddToCart.BackColor = System.Drawing.Color.Blue;
                btnAddToCart.ForeColor = System.Drawing.Color.White;
                btnAddToCart.Text = "Added to Cart";
                Image imgGreenstar = item.FindControl("imgStar") as Image;
                imgGreenstar.Visible = true;
			}
			else
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
    }
