    using System;
    using System.Management;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace Hector
    {
        public class RamInfo
        {
            [DllImport("kernel32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);
    
            public static double RAMSize(SizeType type, SpaceSelector selector)
            {
                try
                {
                    GetPhysicallyInstalledSystemMemory(out long RamSize);
                    var RAMCounter = new PerformanceCounter("Memory", "Available MBytes", true);
    
                    double outValue = 0;
    
                    double RAMTotalSizeBytes = 0, RAMFreeSizeBytes = 0, RAMUsedSizeBytes = 0,
                           RAMTotalSizeKB = 0, RAMFreeSizeKB = 0, RAMUsedSizeKB = 0,
                           RAMTotalSizeMB = 0, RAMFreeSizeMB = 0, RAMUsedSizeMB = 0,
                           RAMTotalSizeGB = 0, RAMFreeSizeGB = 0, RAMUsedSizeGB = 0,
                           RAMTotalSizeTB = 0, RAMFreeSizeTB = 0, RAMUsedSizeTB = 0;
    
                    RAMTotalSizeBytes = RamSize * 1024;
                    RAMFreeSizeBytes = RAMCounter.NextValue() * (1024 * 1024);
                    RAMUsedSizeBytes = RAMTotalSizeBytes - RAMFreeSizeBytes;
    
                    RAMTotalSizeKB = RAMTotalSizeBytes / 1024;
                    RAMFreeSizeKB = RAMFreeSizeBytes / 1024;
                    RAMUsedSizeKB = RAMTotalSizeKB - RAMFreeSizeKB;
    
                    RAMTotalSizeMB = RAMTotalSizeKB / 1024;
                    RAMFreeSizeMB = RAMFreeSizeKB / 1024;
                    RAMUsedSizeMB = RAMTotalSizeMB - RAMFreeSizeMB;
    
                    RAMTotalSizeGB = RAMTotalSizeMB / 1024;
                    RAMFreeSizeGB = RAMFreeSizeMB / 1024;
                    RAMUsedSizeGB = RAMTotalSizeGB - RAMFreeSizeGB;
    
                    RAMTotalSizeTB = RAMTotalSizeGB / 1024;
                    RAMFreeSizeTB = RAMFreeSizeGB / 1024;
                    RAMUsedSizeTB = RAMTotalSizeTB - RAMFreeSizeTB;
    
                    switch (type)
                    {
                        case SizeType.Bytes:
                            switch (selector)
                            {
                                case SpaceSelector.FreeSpace: outValue = RAMFreeSizeBytes; break;
                                case SpaceSelector.TotalSpace: outValue = RAMTotalSizeBytes; break;
                                case SpaceSelector.UsedSpace: outValue = RAMUsedSizeBytes; break;
                            }
                            break;
                        case SizeType.Kilobytes:
                            switch (selector)
                            {
                                case SpaceSelector.FreeSpace: outValue = RAMFreeSizeKB; break;
                                case SpaceSelector.TotalSpace: outValue = RAMTotalSizeKB; break;
                                case SpaceSelector.UsedSpace: outValue = RAMUsedSizeKB; break;
                            }
                            break;
                        case SizeType.Megabytes:
                            switch (selector)
                            {
                                case SpaceSelector.FreeSpace: outValue = RAMFreeSizeMB; break;
                                case SpaceSelector.TotalSpace: outValue = RAMTotalSizeMB; break;
                                case SpaceSelector.UsedSpace: outValue = RAMUsedSizeMB; break;
                            }
                            break;
                        case SizeType.Gigabytes:
                            switch (selector)
                            {
                                case SpaceSelector.FreeSpace: outValue = RAMFreeSizeGB; break;
                                case SpaceSelector.TotalSpace: outValue = RAMTotalSizeGB; break;
                                case SpaceSelector.UsedSpace: outValue = RAMUsedSizeGB; break;
                            }
                            break;
                        case SizeType.Terabytes:
                            switch (selector)
                            {
                                case SpaceSelector.FreeSpace: outValue = RAMFreeSizeTB; break;
                                case SpaceSelector.TotalSpace: outValue = RAMTotalSizeTB; break;
                                case SpaceSelector.UsedSpace: outValue = RAMUsedSizeTB; break;
                            }
                            break;
                    }
    
                    return outValue;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
    
            public static string RamType
            {
                get
                {
                    int type = 0;
    
                    ConnectionOptions connection = new ConnectionOptions();
                    connection.Impersonation = ImpersonationLevel.Impersonate;
                    ManagementScope scope = new ManagementScope("\\\\.\\root\\CIMV2", connection);
                    scope.Connect();
                    ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_PhysicalMemory");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        type = Convert.ToInt32(queryObj["MemoryType"]);
                    }
    
                    return TypeString(type);
                }
            }
    
            private static string TypeString(int type)
            {
                string outValue = string.Empty;
    
                switch (type)
                {
                    case 0x0: outValue = "Unknown"; break;
                    case 0x1: outValue = "Other"; break;
                    case 0x2: outValue = "DRAM"; break;
                    case 0x3: outValue = "Synchronous DRAM"; break;
                    case 0x4: outValue = "Cache DRAM"; break;
                    case 0x5: outValue = "EDO"; break;
                    case 0x6: outValue = "EDRAM"; break;
                    case 0x7: outValue = "VRAM"; break;
                    case 0x8: outValue = "SRAM"; break;
                    case 0x9: outValue = "RAM"; break;
                    case 0xa: outValue = "ROM"; break;
                    case 0xb: outValue = "Flash"; break;
                    case 0xc: outValue = "EEPROM"; break;
                    case 0xd: outValue = "FEPROM"; break;
                    case 0xe: outValue = "EPROM"; break;
                    case 0xf: outValue = "CDRAM"; break;
                    case 0x10: outValue = "3DRAM"; break;
                    case 0x11: outValue = "SDRAM"; break;
                    case 0x12: outValue = "SGRAM"; break;
                    case 0x13: outValue = "RDRAM"; break;
                    case 0x14: outValue = "DDR"; break;
                    case 0x15: outValue = "DDR2"; break;
                    case 0x16: outValue = "DDR2 FB-DIMM"; break;
                    case 0x17: outValue = "Undefined 23"; break;
                    case 0x18: outValue = "DDR3"; break;
                    case 0x19: outValue = "FBD2"; break;
                    default: outValue = "Undefined"; break;
                }
    
                return outValue;
            }
        }
    }
