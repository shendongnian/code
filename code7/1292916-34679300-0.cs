    private DataTable myDataTable; // create a class scoped variable
    private void X()
    {
        MyConnection.Open();
        SqlCommand cm = new SqlCommand("SELECT * FROM table_Price");
    
        cm.Connection = MyConnection;
    
        SqlDataAdapter dataAdapter = new SqlDataAdapter(cm);
        this.myDataTable = new DataTable(); // assign it here
        DataAdapter.Fill(this.myDataTable);
    }
    private void Y()
    {
        // reuse this.myDataTable here
    }
