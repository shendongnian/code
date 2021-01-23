            DataTable t = new DataTable();
            t.Columns.Add("ID");
            t.Columns.Add("Poster");
            t.Columns.Add(new DataColumn("Img", typeof(Bitmap)));
            Bitmap b = new Bitmap(50, 15);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawString("Loading...", this.Font, new SolidBrush(Color.Black), 0f, 0f);
            }
            t.Rows.Add(new object[] { "1", "http://colorvisiontesting.com/images/plate%20with%205.jpg", b });
            dataGridView1.DataSource = t;
            ThreadPool.QueueUserWorkItem(delegate
            {
                foreach (DataRow row in t.Rows)
                {
                    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(row["Poster"].ToString());
                    myRequest.Method = "GET";
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                    System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
                    myResponse.Close();
                    row["Img"] = bmp;
                }
            });
