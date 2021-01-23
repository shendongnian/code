     private void USB_Utility_Load(object sender, EventArgs e)
    {
        lblDisplayStatus.Text = "Detecting Disk Drives...";
    }
    private void tabUSB_Prep_Enter(object sender, EventArgs e)
    {
        tabUSB_Prep.Controls.Clear();
        Task<List<string>> t = new Task<List<string>>(DetectDrivesMethod());
                        t.ContinueWith((result)=>DisplayDrives(result.Result),TaskScheduler.FromCurrentSynchronizationContext);
                        t.Start();
    }
