     foreach (DataRow row in dt.Rows)
        {
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(row[i].ToString() + ",");
            }
            sb.Append(Environment.NewLine);
        }
the loop above iterates through each row of DataTable, and creates a comma separated string for each column value of the. After each row is processed, a new line is added so that the next row contents are added as comma separated string in new line. 
