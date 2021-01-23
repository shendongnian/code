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
    
        for (int i = 0; i < dtTemp.Rows.Count; i++)
        {
            bool isDupe = false;
            for (int j = 0; j < dtAllType.Rows.Count; j++)
            {
                if (dtTemp.Rows[i][0].ToString() == dtAllType.Rows[j][0].ToString())
                {
                    dtAllType.Rows[j][1] = int.Parse(dtAllType.Rows[j][1].ToString()) + int.Parse(dtTemp.Rows[i][1].ToString());
                    isDupe = true;
                    break;
                }
            }
    
            if (!isDupe)
            {
                dtAllType.ImportRow(dtTemp.Rows[i]);
            }
        }
        myConnection.Close();
    }
