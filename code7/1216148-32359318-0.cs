                int i = 0;
                while (dataReader.Read())
                {
                    if (i % 2 == 0)
                        listView2.Items.Add(dataReader.GetValue(0).ToString()).BackColor = Color.Lavender;
                    else
                        listView2.Items.Add(dataReader.GetValue(0).ToString());
                    listView2.Items[i].SubItems.Add(dataReader.GetString(1).ToString());
                    listView2.Items[i].SubItems.Add((dataReader.IsDBNull(2) ? "No place added" : dataReader.GetString(2)));
                    //------------------------------------I meant here !
                    listView2.Items[i].SubItems.Add("0");
                    listView2.Items[i].SubItems.Add("0");
                    listView2.Items[i].SubItems.Add("0");
                    i++;
                }
                dataReader.Close();
