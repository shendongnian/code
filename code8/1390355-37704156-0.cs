    private void listView_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
    {
        **if (e.ColumnIndex == 0)**
        {
            e.Cancel = true;
            e.NewWidth = listView.Columns[e.ColumnIndex].Width;
        }
    }
