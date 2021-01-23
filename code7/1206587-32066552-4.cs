    BackgroundWorker bw = new BackgroundWorker();
    bw.DoWork += bw_DoWok;
    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
    
    void bw_RunWorkerComleted(object sender, RunWorkerCompletedEventAgs e)
    {
        MessageBox.Show("The result is " + e.Result.ToString());
    }
    
    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = ComplexCalculation();
    }
    
    private void button_Click(object sender, RoutedEventArgs e)
    {
        bw.RunWorkerAsync();
    }
