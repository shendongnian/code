    string filter = string.Empty;
    foreach (DataGridViewColumn column in dataGridView1.Columns)
    {
        if (column.Index == 0) 
        {
            filter += string.Format("{0} LIKE '%{1}%'", column.Name, txt_search.Text);
        }
        else
        {
            filter += string.Format(" OR {0} LIKE '%{1}%'", column.Name, txt_search.Text);
        }
    }
    bs.Filter = filter;
