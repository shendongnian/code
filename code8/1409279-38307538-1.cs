    var itemList=new List<string>();
    SqlDataReader sqlReader = sqlCmd.ExecuteReader();
                    while (sqlReader.Read())
                    {
                        string name = sqlReader.GetString(0);
                        combobox1.Items.Add(name);
                        itemList.Add(name);
                    }
                    sqlReader.Close();
                    conn.Close();
                }
