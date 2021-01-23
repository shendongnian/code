    private void Form1_Load(object sender, EventArgs e)
    {
        DataTable oDataTable = new DataTable(); 
        using (SqlConnection oSqlConnection = new SqlConnection(Properties.Settings.Default.ConnectionString))
        {
            using (SqlCommand oSqlCommand = new SqlCommand("select ProductID, ProductName from Product", oSqlConnection))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(oSqlCommand))
                {
                    adapter.Fill(oDataTable);
                }
            }
        }
        listBox1.DisplayMember = "ProductName";
        listBox1.ValueMember = "ProductID";
        listBox1.DataSource = oDataTable;
        
    }
    private void button1_Click(object sender, EventArgs e)
    {
        DataRowView selectedRow = (DataRowView)listBox1.SelectedItem;
        MessageBox.Show(selectedRow["ProductId"].ToString());
    }
