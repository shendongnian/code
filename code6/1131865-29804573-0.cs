    string mySelectQuery = "Select * from " + file;
    string ConStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
    ";Extended Properties=\"Text;HDR=No;FMT=Delimited\"";
    OleDbConnection myConnection = new OleDbConnection(ConStr);
    OleDbCommand myCommand = new OleDbCommand(mySelectQuery, myConnection);
    chart1.DataSource = myCommand;
    for (int i = 0; i < chart1.Series.Count; i++) {
        chart1.Series[i].XValueMember = "1";
        chart1.Series[i].YValueMembers = (i+2).ToString();
    }
    chart1.DataBind(); 
