    using (SqlConnection conn = new SqlConnection(@"Data Source=SHARKAWY;Initial Catalog=Booking;Persist Security Info=True;User ID=sa;Password=123456"))
    {
        try
        {
            string query = "select CategoryName, CategoryID from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            conn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Categories");
            cmbCategories.DisplayMember =  "CategoryName";
            cmbCategories.ValueMember = "CategoryID ";
            cmbCategories.DataSource = ds.Tables["Categories"];
        }
        catch (Exception ex)
        {
            // write exception info to log or anything else
            MessageBox.Show("Error occured!");
        }               
    }
