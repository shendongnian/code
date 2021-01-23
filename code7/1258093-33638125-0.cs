    using (SqlDataReader read1 = com.ExecuteReader())
                    {
                        while (read1.Read())
                        {
                            ListViewItem parent = listView1.Items.Add(read1[0].ToString());
                            parent.SubItems.Add(read1[1].ToString());
                        }
                    }
