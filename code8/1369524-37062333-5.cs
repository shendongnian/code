    DataTable t = new DataTable();
    myConnection.Open();
    string query = string.Format("SELECT Type, Sum(Expense) AS TotalExpenses FROM [{0}] group by Type", table);
    OleDbCommand cmd = new OleDbCommand(query, myConnection);
    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
    adapter.Fill(t);
    myConnection.Close();
