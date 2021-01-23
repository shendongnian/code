        public virtual void Insert(params object[] colValues)
        {
            if (colValues == null || colValues.Length % 2 != 0)
                throw new ArgumentException("Invalid column values passed in. Expects pairs (ColumnName, ColumnValue).");
    
            SqlCommand cmd = new SqlCommand("INSERT INTO " + TableName + " ( {0} ) VALUES ( {1} )");
    
            string insertCols = string.Empty;
            string insertParams = string.Empty;
    
            for (int i = 0; i < colValues.Length; i += 2)
            {
                string separator = ", ";
                if (i == colValues.Length - 2)
                    separator = "";
    
                string param = "@P" + i;
    
                insertCols += colValues[i] + separator;
                insertParams += param + separator;
    
                cmd.Parameters.AddWithValue(param, colValues[i + 1]);
            }
    
            cmd.CommandText = string.Format(cmd.CommandText, insertCols, insertParams);
    
            DA.SqlManager.ExecuteNonQuery(cmd);
        }
