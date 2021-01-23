    private void button1_Click(object sender, EventArgs e)
    {
        backgroundWorker1.RunWorkerAsync(textBox1.Text);
    }
    
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var num = Int32.Parse(e.Argument.ToString()) + 1;
        backgroundWorker1.ReportProgress(num);
        e.Result = num;
    }
    
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = (int)e.ProgressPercentage;
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        textBox1.Text = e.Result.ToString();
    }
