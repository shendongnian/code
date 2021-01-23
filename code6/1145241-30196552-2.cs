    //////////////////////////////////////////////////////////////////////////////////
    //This function is absolute magic >.> - Fill DataTable with excel spreadsheet
    //HDR=YES means "Spreadsheet has headers" Change to NO if not.
    //name = "Log"; - This is the Sheet name to pull the data from
    //////////////////////////////////////////////////////////////////////////////////
    //oconn takes an SQL like command (Select Everything from name sheet) using con
    //HDR=YES means that our data has headers :)
    //////////////////////////////////////////////////////////////////////////////////
    String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + copyToPath + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
    OleDbConnection con = new OleDbConnection(constr);
    OleDbCommand oconn = new OleDbCommand("Select * From [Log$]", con);
    con.Open();
    OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
    DataTable data = new DataTable();
    sda.Fill(data);
    con.Close();
    //////////////////////////////////////////////////////////////////////////////////
