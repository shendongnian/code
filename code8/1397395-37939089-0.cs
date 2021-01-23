    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        try
        {
            listView1.View = View.Details;
            DataTable dtdt = new DataTable();
            dtdt = qr.history(); // query in sql to datatable
            var listItems = new List<ListViewItem>();
            for (int i = 0; i < dtdt.Rows.Count; i++)// loop data to listviewitem
            {
                DataRow dr = dtdt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["custnum"].ToString());
                listitem.SubItems.Add(dr["custname"].ToString().Trim());
                listitem.SubItems.Add(dr["ratecable"].ToString().Trim());
                listitem.SubItems.Add(dr["rateinternet"].ToString().Trim());
                listitem.SubItems.Add(dr["rateext"].ToString().Trim());
                listitem.SubItems.Add(dr["status"].ToString().Trim());
                listitem.SubItems.Add(dr["classname"].ToString().Trim());
                listitem.SubItems.Add(dr["SVCstadd"].ToString().Trim());
                listitem.SubItems.Add(dr["SVCctadd"].ToString().Trim());
                listitem.SubItems.Add(dr["svctelno"].ToString().Trim());
                listitem.SubItems.Add(dr["bilstadd"].ToString().Trim());
                listitem.SubItems.Add(dr["bilctadd"].ToString().Trim());
                listitem.SubItems.Add(dr["billtel"].ToString().Trim());
                listitem.SubItems.Add(dr["billtel2"].ToString().Trim());
                listitem.SubItems.Add(dr["fax"].ToString().Trim());
                listitem.SubItems.Add(dr["zoneno"].ToString().Trim());
                listitem.SubItems.Add(dr["zoneName"].ToString().Trim());
                listitem.SubItems.Add(dr["bookno"].ToString().Trim());
                listitem.SubItems.Add(dr["seqno"].ToString().Trim());
                listitem.SubItems.Add(dr["Balance"].ToString().Trim());
                listitem.SubItems.Add(dr["balance1"].ToString().Trim());
                listitem.SubItems.Add(dr["balance2"].ToString().Trim());
                listitem.SubItems.Add(dr["balance3"].ToString().Trim());
                listitem.SubItems.Add(dr["billamnt"].ToString().Trim());
                listitem.SubItems.Add(dr["maxdate"].ToString().Trim());
                listItems.Add(listitem);
            }
            this.BeginInvoke(((Action)(() => { listView1.Items.AddRange(listItems.ToArray()); })));
        }
        catch (System.Exception exc)
        {
            this.BeginInvoke(((Action)(() => { MessageBox.Show("BackgroundWorker error: " + exc);})));
        }
    }
