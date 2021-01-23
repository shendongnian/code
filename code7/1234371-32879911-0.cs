    protected void btnAdd_Click(object sender, EventArgs e)
    {
        bool existingSupply = IsExisting();
        foreach (ListViewItem item in lvPODetails.Items)
        {
            TextBox quantity = (TextBox)item.FindControl("txtQuantity");
            Label ltr = (Label)item.FindControl("lblProduct");
            TextBox odr = (TextBox)item.FindControl("txtOrdered");
    
            string name = ltr.Text;
            int delivered = Convert.ToInt32(quantity.Text);
            int ordered = Convert.ToInt32(odr.Text);
            string status = String.Empty;
    
    
            if (delivered >= ordered)
            {
                status = "Complete";
    
            }
    
    
    
    
            if (delivered < ordered)
            {
                status = "Partially Completed";
    
            }
    
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            if (existingSupply)
            {
                cmd.CommandText = "UPDATE Inventory SET Quantity=quantity + @Quantity WHERE ProductID=@ProductID";
    
            }
    
            else
            {
                cmd.CommandText = "INSERT INTO Inventory VALUES (@ProductID, @ProdCatID, @SupplierName, " +
                    "@Quantity, @CriticalLevel, @Price, @Status, @DateAdded, @DateModified)";
    
            }
    
            cmd.Parameters.AddWithValue("@ProductID", name);
            cmd.Parameters.AddWithValue("@ProdCatID", DBNull.Value);
            cmd.Parameters.AddWithValue("@SupplierName", txtSupplier.Text);
            cmd.Parameters.AddWithValue("@Quantity", delivered);
            cmd.Parameters.AddWithValue("@CriticalLevel", DBNull.Value);
            cmd.Parameters.AddWithValue("@Price", DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", DBNull.Value);
            cmd.Parameters.AddWithValue("@DateAdded", DateTime.Now);
            cmd.Parameters.AddWithValue("@DateModified", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd1 = new SqlCommand("UPDATE PurchaseOrder SET POStatus=@POStatus WHERE PONo=@PONo", con);
            
            cmd1.Parameters.AddWithValue("@POStatus", status);
            cmd1.Parameters.AddWithValue("@PONo", txtPONo.Text);
    
            cmd1.ExecuteNonQuery();
            con.Close();
    
        }
        Response.Redirect("Default.aspx");         
    } 
