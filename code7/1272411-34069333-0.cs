    private void Library_StatusChanged(object sender, AbstractTestCase.StatusChangedEventArgs e)
    {
        this.lblProgress.Invoke((MethodInvoker)delegate ()
        {
            lblProgress.Text = "Current state: " + e.Step;
        });
    
        this.pbProgess.Invoke((MethodInvoker)delegate ()
        {
            pbProgess.Value = e.Percentage;
        });
    
        this.lstStatus.Invoke((MethodInvoker)delegate ()
        {
            lstStatus.Items.Add("    " + e.Step);
        });
    }
