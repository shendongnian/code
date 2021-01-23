               DataTable dt1 = new DataTable();
                dt1.Columns.Add("Name", typeof(string));
                dt1.Rows.Add(new string[] {"Mani"});
                dt1.Rows.Add(new string[] {"Ram"});
                dt1.Rows.Add(new string[] {"Guna"});
                dt1.Rows.Add(new string[] {"Praveen"});
                dt1.Rows.Add(new string[] {"Jai"});
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Name", typeof(string));
                dt2.Rows.Add(new string[] {"kumar"});
                dt2.Rows.Add(new string[] {"bharath"});
                dt2.Rows.Add(new string[] {"ashok"});
                dt2.Rows.Add(new string[] {"vikram"});
                dt2.Rows.Add(new string[] {"san"});
                DataTable dt3 = dt1.Copy();
                foreach (DataRow row in dt2.AsEnumerable())
                {
                    dt3.Rows.Add(row.ItemArray);
                }
                dataGridView1.DataSource = dt3;​
