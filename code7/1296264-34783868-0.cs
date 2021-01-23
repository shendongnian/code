            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.TableName = "JobDetails";
            dt1.Columns.Add("JobNum");
            dt1.Columns.Add("Detail1");
            dt1.Columns.Add("Detail2");
            ds.Tables.Add(dt1);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["JobDetails"].NewRow();
                row1["JobNum"] = r.Cells[0].Value.ToString();
                row1["Detail1"] = r.Cells[1].Value.ToString();
                row1["Detail2"] = r.Cells[2].Value.ToString();
                ds.Tables["JobDetails"].Rows.Add(row1); 
            }
            ds.WriteXml("..\\..\\..\\xmlSample.xml");
