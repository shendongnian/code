                string connStr = "Enter Your connection String Here";
                string SQL = "Enter Your SELECT Here";
                SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                DataTable ds = new DataSet();
                adapter.Fill(ds);
                ds.WriteXml("FileName", XmlWriteMode.WriteSchema);
