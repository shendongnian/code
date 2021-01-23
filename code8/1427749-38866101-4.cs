    DataGridView myTabGridView = tabControl_Roz.TabPages[0].
                                 Controls.Where(c=>c is DataGridView && 
                                                ((DataGridView)c).Name == "dataGridView_" + "test1").
                                 FirstOrDefault();
    if(myTabGridView != null)
    {
        myTabGridView.DataSource = xxx;
    }
