    private delegate void SetListProperties(DataTable myData);
	
	private void UpdateListView(DataTable myData)
    {
        if (lstVUser.InvokeRequired)
        {
			SetListProperties d = new SetListProperties(UpdateListView);
            lstVUser.BeginInvoke(d, myData);
        }
        else
        {
           for (int i = 0; i < dt.Rows.Count; i++)
           {
               DataRow dr = dt.Rows[i];
               ListViewItem listitem = new ListViewItem(dr[0].ToString());
               listitem.SubItems.Add(dr[1].ToString().PadLeft(3));
               listitem.SubItems.Add(dr[2].ToString().PadLeft(3));
               lstVUser.Items.Add(listitem);
           }
        }
    }
