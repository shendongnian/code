    //First we declare a static string that can be accessed by the whole form
    //and blank it so the form doesnt use a previous value.
    public static string product_type = ""
    //In the form load event, the gridview is populated - this could be moved to anywhere.
    private void Form1_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection("DB connection string");
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Products", conn);
        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sqlDataAdap.Fill(ds);
        DataTable dt = new DataTable();
        sqlDataAdap.Fill(dt);
        conn.Close();
    }
    //In the cell contect click event we give it the ProductType 
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        //Here we declare a var to identify that we're looking at the row
        var row = dataGridView1.CurrentRow.Cells;
        //Now we set the string we declared earlier
        product_type = Convert.ToString(row["ProductType"].Value);
    
        //Now we repeat the grid script with a parameter which uses our string from above
        SqlConnection conn = new SqlConnection("DB connection string");
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Products WHERE ProductType = @ProductType", conn);
        sc.Parameters.Add("@ProductType", SqlDbType.Int).Value = product_type;
        SqlDataAdapter sqlDataAdap = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sqlDataAdap.Fill(ds);
        DataTable dt = new DataTable();
        sqlDataAdap.Fill(dt);
        conn.Close();
    }
