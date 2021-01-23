    private void Form1_Load(object sender, EventArgs e)
    {
        DriveInfo[] ListDrives = DriveInfo.GetDrives();
        foreach (DriveInfo Drive in ListDrives)
        {
            if (Drive.DriveType == DriveType.Removable)
            {
                ListOfDrivers.DataSource = ListDrives.ToList();
            }
        }
    }
