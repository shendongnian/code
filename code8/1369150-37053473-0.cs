    bool bSATA = false;
    foreach (ManagementObject o in res.Get())
    {
         string sCaption = o["Caption"].ToString();
         if(sCaption.Contains("ATA"))
         {
              bSATA = true;
              break;
         }
    }
    if(bSATA)
        Console.WriteLine("SATA Drive");
