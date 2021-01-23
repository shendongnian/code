            DataTable dt;
            using (Stream fileStream = fileUpload.PostedFile.InputStream)
            using (StreamReader sr = new StreamReader(fileStream))
            {
                string a = null;
                while ((a = sr.ReadLine()) != null)
                {
                    string[] columns = a.Split(',');
                    if (dt == null)
                    {
                        dt = new DataTable();
                        for (int i = 0; i < columns.Count(); i++)
                            dt.Columns.Add(new DataColumn(i.ToString(), typeof(string)));
                    }
                    dt.Rows.Add(columns);
                }
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
