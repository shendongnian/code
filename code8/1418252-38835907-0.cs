                StreamReader sr = new StreamReader(@filePath);
                string line = sr.ReadLine();
                string[] value = line.Split(',');
                DataTable dt = new DataTable();
                DataRow row;
                foreach (string dc in value)
                {
                    dt.Columns.Add(new DataColumn(dc));
                }
                while (!sr.EndOfStream)
                {
                    value = sr.ReadLine().Split(',');
                    if (value.Length == dt.Columns.Count)
                    {
                        row = dt.NewRow();
                        row.ItemArray = value;
                        dt.Rows.Add(row);
                    }
                }
                dgv.DataSource = dt;
                conn.Open();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [receipts] ([fullname], [state], [regno], [dept], [year], [session], [amount], [date], [faculty], [bank], [jamb]) VALUES('" + dt.Rows[i][1].ToString() + "', '" + dt.Rows[i][2].ToString() + "', '" + dt.Rows[i][3].ToString() + "', '" + dt.Rows[i][5].ToString() + "', '" + dt.Rows[i][6].ToString() + "', '" + dt.Rows[i][7].ToString() + "', '" + dt.Rows[i][8].ToString() + "', '" + dt.Rows[i][9].ToString() + "', '" + dt.Rows[i][10].ToString() + "', '" + dt.Rows[i][11].ToString() + "', '" + dt.Rows[i][4].ToString() + "')", conn);
                    command.ExecuteNonQuery();
                }
                conn.Close();
