    List<String> tableList = serviceMethod.getTableList();
    DataTable dtAllType = new DataTable();
    foreach (string table in tableList)
    {
        DataTable dtTemp = new DataTable();
        myConnection.Open();
        string query = string.Format("SELECT Type, Sum(Expense) AS TotalExpenses FROM [{0}] group by Type", table);
        OleDbCommand cmd = new OleDbCommand(query, myConnection);
        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
        adapter.Fill(dtTemp);
        myConnection.Close();
        dtAllType.Merge(dtTemp);
    }
