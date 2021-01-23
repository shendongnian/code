    protected void CalculateTotal()
    {
        string cnnString = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
        SqlConnection conn = new SqlConnection(cnnString);
        conn.Open();
        SqlCommand cmd1 = new SqlCommand("select sum (quantity * price) from cart", conn);
        lblsubtotal.Text = Convert.ToString(cmd1.ExecuteScalar());
        conn.Close()
    }
