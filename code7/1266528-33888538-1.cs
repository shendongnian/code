        using System.IO;
        private void button4_Click(object sender, EventArgs e)
        {
          IWshNetwork_Class network = new IWshNetwork_Class();
    
          string drive = Path.GetPathRoot("k:");
          if(!Directory.Exists(drive))
          {
                
           network.MapNetworkDrive(drive, @"\\10.*.*.*\d$\test", Type.Missing, "local\\blabla", "*******");
                
           System.Diagnostics.Process.Start("file:///K:\\gemy.exe");                        
          }
          else
          {  
            //This is the closing part
            network.RemoveNetworkDrive("k:");
          }
        }
