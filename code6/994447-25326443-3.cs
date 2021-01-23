    private void Form1_Load(object sender, EventArgs e)
    {
        ListOfDrivers.DataSource = 
                                   DriveInfo.GetDrives()
                                   .Where(x => x.DriveType == DriveType.Removable)
                                   .ToList();
    }
