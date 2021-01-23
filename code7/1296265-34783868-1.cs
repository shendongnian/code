            DataSet ds = new DataSet();
            ds.ReadXml("..\\..\\..\\xmlSample.xml");
            foreach (DataRow item in ds.Tables["JobDetails"].Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value =     item["JobNum"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["Detail1"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = item["Detail2"].ToString();
            }
