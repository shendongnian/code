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
    DataTable dtFinal = dtAllType.Clone();
    for (int i = 0; i < dtAllType.Rows.Count; i++)
    {
        bool isDupe = false;
        for (int j = 0; j < dtFinal.Rows.Count; j++)
        {
            if (dtAllType.Rows[i][0].ToString() == dtFinal.Rows[j][0].ToString())
            {
                dtFinal.Rows[j][1] = int.Parse(dtFinal.Rows[j][1].ToString()) + int.Parse(dtAllType.Rows[i][1].ToString());
                isDupe = true;
                break;
            }
        }
    
        if (!isDupe)
        {
            dtFinal.ImportRow(dtAllType.Rows[i]);
        }
    }
