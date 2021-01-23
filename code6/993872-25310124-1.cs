    private void startButton_Click(object sender, EventArgs e)
    {
        DriveInfo[] drives = DriveInfo.GetDrives();
        string drivenames = string.Empty;
        for (int i = 0; i < drives.Count(); i++)
        {
            drivenames = drives[i].Name;
            MessageBox.Show(drivenames); // --> For debug purposes only
        }
    }
