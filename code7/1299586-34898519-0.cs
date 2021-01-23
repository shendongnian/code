    private int[] columnViewIndex = Enumerable.Repeat(0, 10)
        .Concat(Enumerable.Repeat(1, 10))
        .Concat(Enumerable.Repeat(2, 10))
        .ToArray();
    
    private void moveToFirstGridToolStripMenuItem1_Click(object sender, EventArgs e)
    {
        dataGridView3.Columns[currentColumnIndex].Visible = false;
        dataGridView1.Columns[currentColumnIndex].Visible = true;
        columnViewIndex[currentColumnIndex] = 0; // 1, 2 in other move methods
        currentColumnIndex = -5;
    }
    
    private void DataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        var view = sender as DataGridView;
        int viewIndex = view == this.dataGridView1 ? 0 : view == this.dataGridView2 ? 1 : 2;
        bool anyVisible = false;
        for (int i = 0; i < this.m_CurrentTable.Columns.Count; i++)
        {
            bool visible = i < columnViewIndex.Length && columnViewIndex[i] == viewIndex;
            view.Columns[i].Visible = visible;
            anyVisible = anyVisible || visible;
        }
    
        view.RowHeadersVisible = anyVisible;
        view.ScrollBars = anyVisible ? ScrollBars.Both : ScrollBars.None;
    }
