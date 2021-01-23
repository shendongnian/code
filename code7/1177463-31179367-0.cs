     public string[] RowOnly()
        {
                       
            conn = new OleDbConnection(connStr);
            conn.Open();
            cmd = new OleDbCommand(query, conn);
            data = cmd.ExecuteReader();
            MessageBox.Show(data.HasRows.ToString());
            int i = data.FieldCount;
            List<string> SingleRow = new List<string>();
           while (data.Read())
            {
                for (int c = 0; c < i; c++)
                {
                    SingleRow.Add(data[c].ToString());
                }
                               
            }
            conn.Close();
            return SingleRow.ToArray();
          
        }
