    var Cn = new System.Data.SqlClient.SqlConnection();
    Cn.ConnectionString = "Server=.\\SqlExpress;Database=YourDatabasename;Trusted_Connection=True";
    Cn.Open();
    var Cm = Cn.CreateCommand();
    Cm.CommandText = string.Format(@"Select * From DataTablename");
    var Dr = Cm.ExecuteReader();
        
    //add all data from database to dropdownlist
    while (Dr.Read())
        {
           RiskWorkDropDownList.Items.Add(new ListItem(Dr.GetValue(1/*your table column*/).ToString()));
        }
        
    Cn.Close();
