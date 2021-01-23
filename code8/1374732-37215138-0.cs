    using System.IO;
    protected void Page_Load(object sender, EventArgs e)
        {
            foreach(DriveInfo di in DriveInfo.GetDrives())
            {
                lstdrive.Items.Add(di.ToString());
            }
        }
