    public string RAM_Type()
            {
        
                int type=0;
                var searcher = new ManagementObjectSearcher("Select * from Win32_PhysicalMemory");
                foreach (ManagementObject obj in searcher.Get())
                {
                   type = Int32.Parse(obj.GetPropertyValue("MemoryType").ToString());
        
                }
        
                switch (type)
                {
                    case 20:
                        return "DDR";
                        break;
                    case 21:
                        return "DDR-2";
                        break;
                    case 17:
                        return "SDRAM";
                        break;
                    default:
                        if (type == 0 || type > 22)
                            return "DDR-3";
                        else
                            return "Unknown";
                }
        
            }
