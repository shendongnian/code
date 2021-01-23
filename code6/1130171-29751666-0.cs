    foreach (DataTable aDataTable in aDataSet.Tables)
        {
            for (int i = 0; i < aDataTable.Rows.Count; i++)
            {
              rtf = aDataTable.Rows[i]["interpretation_text_rtf"].ToString();
              version = aDataTable.Rows[i]["version"].ToString();
              File.WriteAllText(mPath + rtfFile + i + version +".rtf", rtf);
            }
        }  
