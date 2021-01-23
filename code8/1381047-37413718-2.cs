    public void GridViewBind()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["OLEDB"].ToString();
        string selectCommand = "SELECT equipment, primekey FROM PI_EVENT_TABLE WHERE primekey = " 
        + DropDownList1.SelectedValue;
        
        DataTable table = new DataTable();
        using(var con = new OleDbConnection(connectionString))
        using(var command = new OleDbCommand(selectCommand, con))
        {
            con.Open();
            try
            {
               table.Load(command.ExecuteReader());
               GridView1.DataSource = table;
               GridView1.DataBind();
            }
            catch(Exception) // place break point here to see if you have exceptions
            {
               throw;
            }
        }
    }
