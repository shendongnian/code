    private bool closingForm = false;
    
    // Note, this is "Closing" event handler, not "Close"
    Form1_Closing(object sender, CancelEventArgs e)
    {
        if (!closingForm && MessageBox.Show("You sure?", "Form1", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            e.Cancel = true;
        }
        else if (backgroundWorker1.IsBusy)
        {
            e.Cancel = true;
            closingForm = true;
            backgroundWorker1.CancelAsync();
        }
    }
    
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (closingForm)
            this.Close();
    }
