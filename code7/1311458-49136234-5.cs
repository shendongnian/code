    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);            
    public enum SizeType
            {
                Bytes = 0,
                Kilobytes = 1,
                Megabytes = 2,
                Gigabytes = 3,
                Terabytes = 4
            }
    
            public enum SpaceSelector
            {
                FreeSpace = 0,
                UsedSpace = 1,
                TotalSpace = 2
            }
    
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
