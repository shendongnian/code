    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                {
                    string name = sqlReader.GetString(0);
                    combobox1.Items.Add(name);
                    comboBoxList.Items.Add(name);
                }
                sqlReader.Close();
                conn.Close();
            }
