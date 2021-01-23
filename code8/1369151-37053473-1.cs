    foreach (ManagementObject o in res.Get())
    {
         string sCaption = o["Caption"].ToString();
         if(sCaption.Contains("ATA"))
         {
              Console.WriteLine("SATA Drive");
              break;
         }
    }
    
        
