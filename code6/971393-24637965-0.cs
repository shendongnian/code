     for(int i = 0; i <= AgentCodeArray.Length - 1; i++)
     {
         for (int y = OriginalDataTable.Rows.Count - 1; y >= 0; y--)
         {
             if (OriginalDataTable.Rows[y]["Agent_Code"].ToString() == AgentCodeArray[i].ToString())
             {
                 OriginalDataTable.Rows[y].Delete();
             }
         }
     }
