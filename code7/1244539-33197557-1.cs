    string sql = "UPDATE {0} SET [itemcount] = [itemcount] - {1} WHERE [itemcode] = {2} AND [itemcount] IS NOT NULL";
    foreach (ListViewItem item in listView1.Items)
    {
    	string qry = string.Format(sql, item.SubItems[1].Text, item.SubItems[0].Text, item.Text);
        using(cm = new SqlCommand(qry, cn))
    	{
    	   cn.Open();
    	   cm.ExecuteNonQuery();
           cn.Close();
    	}
    }
