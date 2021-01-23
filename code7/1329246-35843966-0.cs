    //string variable to capture product Ids for selected products
    System.Text.StringBuilder productIds = new System.Text.StringBuilder(string.empty);
    for (int i = 0; i < Products.Rows.Count; i++)
    {
        DataGridViewRow dr = Products.Rows[i];
        if (dr.Selected == true)
        {
            Products.Rows.RemoveAt(i);
            
            productIds.Append(productIds.length > 0 ? "," + Convert.ToString(dr["ProductId"]) : Convert.ToString(dr["ProductId"]));
        }
    }
    DeleteProducts(productIds.ToString());
