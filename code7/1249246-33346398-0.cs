    protected void btnRemove(object sender, EventArgs e)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("delete from Car where CarID= @CarID", conn);
        cmd.Parameters.AddWithValue("@CarID", lstCar.SelectedValue);
        SqlCommand cmd1 = new SqlCommand("delete from Orders where OrderID= @OrderID" , conn);
        cmd1.Parameters.AddWithValue("@OrderID", lstOrders.SelectedValue);
        cmd.ExecuteNonQuery();
        cmd1.ExecuteNonQuery();
        conn.Close();
    }
