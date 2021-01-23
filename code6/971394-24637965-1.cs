    for (int y = OriginalDataTable.Rows.Count - 1; y >= 0; y--)
    {
        int count = 0;
        for (int i = 0; i <= AgentCodeArray.Length - 1; i++)
        {
            if (OriginalDataTable.Rows[y]["Agent_Code"].ToString() != AgentCodeArray[i].ToString())
            {
                count++;
                if (count == AgentCodeArray.Length)
                    OriginalDataTable.Rows[y].Delete();
            }
        }
    }
