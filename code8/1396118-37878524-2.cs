    public static void Main(string[] args)
    {
        // Be explicit and keep it initialized as null, so you could 
        // check it at the end of the loop if there are drives to process
        Process XVirus = null;
        // We are interested only in the removable drives. 
        // Linq is good choice here
        foreach (DriveInfo drive in DriveInfo.GetDrives()
                           .Where(x => x.DriveType == DriveType.Removable && 
                                       x.IsReady)
        {
             XVirus = new Process();
             ..... initialize the XVirus operating parameters ...
        }
        // At the end if XVirus is still null we know that 
        // no removable drives  are available
        if(XVirus == null)
            MessageBox.Show("You don't have any removable drive ready")
        else
            ..... process the found drive ....
    }
