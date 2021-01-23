    private void cb_oname_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Safety check, SelectedIndexChanged is called also when there is
        // no item selected (see later)
        if(cb_oname.SelectedIndex < 0)
            return;
        using(SqlConnection sqlConnection = new SqlConnection(.....))
        using(SqlCommand sqlCmd2 = new SqlCommand(@"SELECT Product_category 
                         FROM Product2 WHERE Product_Name=@name", sqlConnection)
        {
            sqlConnection.Open();
            sqlCmd2.Parameters.Add("@name", SqlDbType.NVarChar).Value = cb_oname.SelectedItem;
    
            using(SqlDataReader sqlrdr = sqlCmd2.ExecuteReader())
            {
                while (sqlrdr.Read())
                    cb_ocat.Items.Add(sqlrdr["Product_category"].ToString());
            }
        }
        // Remove from the Items collection, but it is not enough
        cb_oname.Items.RemoveAt(cb_oname.SelectedIndex);
        // Set the selectedindex to -1 so the current text in the combo is reset        
        cb_oname.SelectedIndex = -1;
    }
