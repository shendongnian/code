    private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
    {
        string findFilter = gridView1.FindFilterText;
        if (!string.IsNullOrEmpty(findFilter))
            MessageBox.Show(findFilter);
    }
