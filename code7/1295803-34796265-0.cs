                // your connection string + open connection
                OracleConnection conn = new OracleConnection(global::IssueTracker.Properties.Settings.Default.ConnectionString);
                conn.Open();
                // data adapter
                OracleDataAdapter oa = new OracleDataAdapter("select naziv from vrsteproblema", conn);
                DataSet ds = new DataSet();
                oa.Fill(ds, "vrsteproblema");
                // put entries into a list
                List<string> comboNazivi = new List<string>();
                foreach (DataRow row in ds.Tables["vrsteproblema"].Rows)
                {
                    comboNazivi.Add(row["naziv"].ToString());
                }
    
                // add custom entry
                comboBox2.Items.Add("Svi");
                // fill the rest from the list
                for (var i = 0; i < comboNazivi.Count; i++) {
                    comboBox2.Items.Add(comboNazivi[i]);
                }
                
                // dont forget to close conn
                conn.Close();
