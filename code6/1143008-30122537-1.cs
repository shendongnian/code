    for (int i = 0; i <= dsEmp.Tables[0].Rows.Count; i++)
    {
        for (int j = 0; j <= dsAllTables.Tables[0].Rows.Count; j++)
        {
            if (dsEmp.Tables[0].Rows[i]["EmpName"].ToString() == dsAllTables.Tables[2].Rows[j]["EmpName"].ToString())
            {
            }
        }
    }
