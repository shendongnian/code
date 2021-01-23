    public void GridViewBind()
    {
        string selectCommand = "SELECT equipment, primekey FROM PI_EVENT_TABLE WHERE primekey = " 
        + DropDownList1.SelectedValue;
        
        DataTable table = new DataTable();
        using(var con = new OleDbConnection(conn))
        using(var command = new OleDbCommand(selectCommand, con))
        {
            try
            {
               table.Load(command.ExecuteReader());
               GridView1.DataSource = table;
               GridView1.DataBind();
            }
            catch(Exception)
            {
               throw;
            }
        }
    }
