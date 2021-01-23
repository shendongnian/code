    private void videosInsertRequest_ResponseReceived(Video obj)
    {
        stringProgressReport[0] = obj.Status.UploadStatus;
        backgroundWorker1.ReportProgress(0, 0);
    }
    private void videosInsertRequest_ProgressChanged(IUploadProgress obj)
    {
        stringProgressReport[1] = obj.Status.ToString();
        backgroundWorker1.ReportProgress(0, 1);
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        int eventIndex = (int)e.UserState;
        if (eventIndex == 0)
        {
            toolStripStatusLabel1.Text = stringProgressReport[0];
        }
        else
        {
            toolStripStatusLabel2.Text = stringProgressReport[1];
        }
    }
