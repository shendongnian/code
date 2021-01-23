    DataGridView myTabGridView = tabControl_Roz.TabPages[i].
                                 Controls.Where(c=>c is DataGridView && 
                                                c.Name == "dataGridView_" + "test1").
                                 FirstOrDefault();
    if(myTabGridView != null)
    {
        myTabGridView.DataSource = xxx;
    }
