    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        var files = File.ReadAllLines( @"C:\file.txt" );
        for( int i = 0; i < files.Length; i++ )
        {
            var line = files[i];
            // do work on the current line here
            int percentage = (int)( ( i / (double)files.Length ) * 100.0 );
            bw.ReportProgress( percentage );
        }
    }
    private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
        toolStripLabel1.Text = e.ProgressPercentage.ToString() + "%";
        this.Text = e.ProgressPercentage.ToString();
    }
