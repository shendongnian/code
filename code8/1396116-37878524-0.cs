    public static void Main(string[] args)
    {
        // Be explicit and keep it initialized as null, so you could 
        // check it at the end of the loop if there are drives to process
        Process XVirus = null;
        foreach (DriveInfo drive in DriveInfo.GetDrives()
                           .Where(x => x.DriveType == DriveType.Removable)
        {
             XVirus = new Process();
             ..... initialize the XVirus operating parameters
        }
        if(XVirus == null)
            MessageBox.Show("You don't have any removable drive ready")
        else
            ..... process the found drive ....
    }
