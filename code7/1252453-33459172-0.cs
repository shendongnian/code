    private void button1_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        dt.Columns.Add("Salutation", typeof(string));
        dt.Columns.Add("Name", typeof(string));
        dt.Columns.Add("Sex", typeof(string));
        dt.Columns.Add("Date", typeof(string));
        dt.Columns.Add("Fees_Amount", typeof(string));
        dt.Columns.Add("Fees_Status", typeof(string));
        //add datagridview data to table
        foreach (DataGridViewRow dgv in dgvOldData2.Rows)
        {
            dt.Rows.Add(dgv.Cells[0].Value, dgv.Cells[1].Value, dgv.Cells[2].Value, dgv.Cells[3].Value, dgv.Cells[4].Value, dgv.Cells[5].Value);
        }
        ds.Tables.Add(dt);
        ds.WriteXmlSchema("sample.xml");
        //transefer data to crystalreportviewer
        Reports.CrystalReport1 cr = new Reports.CrystalReport1();
        cr.SetDataSource(ds);
        form1 f = new form1();
        f.LinkReport(cr);
        f.Show();
    }
