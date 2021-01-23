    private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        DataGridView view = sender as DataGridView;
        bool anyVisible = false;
        int max = 0, min = 0;
        if (view == this.dataGridView1)
        {
            min = 0;
            max = 10;
        }
        else if (view == this.dataGridView2)
        {
            min = 10;
            max = 20;
        }
        else if (view == this.dataGridView3)
        {
            min = 20;
            max = 30;
        }
        for (int i = 0; i < this.table.Columns.Count; i++)
        {
            view.Columns[i].Visible = i >= min && i < max;
            anyVisible = anyVisible || view.Columns[i].Visible;
        }
        view.RowHeadersVisible = anyVisible;
        view.ScrollBars = anyVisible ? ScrollBars.Both : ScrollBars.None;
    }
