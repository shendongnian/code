     . . . . 
         MyProgress[] arrP;
         prog.CopyTo(arrP);
         worker.ReportProgress(0, arrP);
     . . . 
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
       
        MyProgress[] progArr  = (MyProgress[])e.UserState;
        foreach (MyProgress p in progArr)
        {
            int rowIdx = dataGridView1.Rows.Add();
                dataGridView1.Rows[rowIdx].Cells[3].Value = p.Progress;
        }
    }
