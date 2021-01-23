    string query;
    SqlCommand SqlCommand;
    SqlDataReader result;
    int sindex=DropDownList1.SelectedIndex+1;
    int hindex =DropDownList3.SelectedIndex+1;
    SqlDataAdapter adapter = new SqlDataAdapter();
    //Open the connection to db
    conn.Open();                
    query = string.Format("select * from table where clumn='"+s+"' ", s);
    SqlCommand = new SqlCommand(query, conn);
    adapter.SelectCommand = new SqlCommand(query, conn);              
    result = SqlCommand.ExecuteReader();               
