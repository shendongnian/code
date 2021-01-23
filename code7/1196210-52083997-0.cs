    //you can use this
    //its working with me very fine on windows 10
    //replace the word bios with any hardware name you want
    //data also can be found with using windows application named (wbemtest) 
    
    using System.Management;
    public static async Task<string> ReturnHardWareID()
            {
                string s = "";
                Task task = Task.Run(() =>
                {
                    ManagementObjectSearcher bios = new ManagementObjectSearcher("SELECT * FROM Win32_BIOS");
                    ManagementObjectCollection bios_Collection = bios.Get();
                    foreach (ManagementObject obj in bios_Collection)
                    {
                        s = obj["SerialNumber"].ToString();
                        break; //break just to get the first found object data only
                    }
                });
                Task.WaitAll(task);
                
                return await Task.FromResult(s);
            }
