    int dataGridViewIndex = tabControl_Roz.TabPages[0].Controls.IndexOfKey("dataGridView_" + "test1");
    if(dataGridViewIndex >= 0)
    {
        DataGridView myTabGridView = tabControl_Roz.TabPages[0].Controls[dataGridViewIndex] as DataGridView;
        if(myTabGridView != null)
        {
            myTabGridView.DataSource = xxx;
        }
    }
