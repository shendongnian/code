    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        UpdateDataGridView();
    }
    delegate void UpdateDataGridViewDelegate(string args);
    private void UpdateDataGridView(string args)
    {
       if (dataGridView.InvokeRequired)
           dataGridView.Invoke(new UpdateDataGridViewDelegate(UpdateDataGridView), args);
       else
        {
            //update datagridview
        }
    }
