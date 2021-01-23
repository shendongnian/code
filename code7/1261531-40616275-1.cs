    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString); 
         
    foreach (ListViewItem item in lvPOItem.Items)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO PurchasePOItems (PO_ItemName, PO_Specs, PO_PONumber)values(@PO_ItemName, @PO_Specs,@PO_PONumber)", conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@PO_ItemName", item.SubItems[0].Text);
        cmd.Parameters.AddWithValue("@PO_Specs", item.SubItems[1].Text);
        cmd.Parameters.AddWithValue("@PO_PONumber", cbPurchaseOrderNo.Text);
        cmd.ExecuteNonQuery();
        conn.Close();
    }
        
