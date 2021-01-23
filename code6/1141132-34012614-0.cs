    using System.Management
    private List<string> ListPrograms()
    {
        List<string> programs = new List<string>();
    
        try
        {
            ManagementObjectSearcher mos = 
              new ManagementObjectSearcher("SELECT * FROM Win32_Product");
            foreach (ManagementObject mo in mos.Get())
            {
                try
                {
                    //more properties:
                    //http://msdn.microsoft.com/en-us/library/windows/desktop/aa394378(v=vs.85).aspx
                    programs.Add(mo["Name"].ToString());
    
                }
                catch (Exception ex)
                {
                    //this program may not have a name property
                }
            }
    
            return programs;
    
        }
        catch (Exception ex)
        {
            return programs;
        }
    }
