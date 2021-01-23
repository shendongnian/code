    public void GenerateCSVfiles(DataSet dataSets)
    {
        //create csv file
        StreamWriter sw = null;
        StringBuilder sb = new StringBuilder();
        foreach (DataTable dataTable in dataSets.Tables)
        {
            sw = new StreamWriter(string.Format(@"C:\Temp\{0}.csv", dataTable.TableName));
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                sb.Clear();
                for (int j = 0; j < dataTable.Columns.Count; j++)
                {
                    sb.Append(dataTable.Rows[i][j]);
                    if (j != (dataTable.Columns.Count - 1)) sb.Append(",");
                }
                sw.WriteLine(sb.ToString());
            }
            sw.Close();
        }
    }
   
   
