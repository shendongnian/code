    /// <summary>
    /// https://msdn.microsoft.com/en-us/library/ee488368.aspx
    /// This structure contains information about current memory availability. The GlobalMemoryStatus function uses this structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryStatus
    {
        /// <summary>
        /// Specifies the size, in bytes, of the MEMORYSTATUS structure.
        /// Set this member to sizeof(MEMORYSTATUS) when passing it to the GlobalMemoryStatus function.
        /// </summary>
        public int Length;
        /// <summary>
        /// Specifies a number between zero and 100 that gives a general idea of current memory use, in which zero indicates no memory use and 100 indicates full memory use.
        /// </summary>
        public uint MemoryLoad;
        /// <summary>
        /// Indicates the total number of bytes of physical memory.
        /// </summary>
        public uint TotalPhys;
        /// <summary>
        /// Indicates the number of bytes of physical memory available.
        /// </summary>
        public uint AvailPhys;
        /// <summary>
        /// Indicates the total number of bytes that can be stored in the paging file.
        /// This number does not represent the physical size of the paging file on disk.
        /// </summary>
        public uint TotalPageFile;
        /// <summary>
        /// Indicates the number of bytes available in the paging file.
        /// </summary>
        public uint AvailPageFile;
        /// <summary>
        /// Indicates the total number of bytes that can be described in the user mode portion of the virtual address space of the calling process.
        /// </summary>
        public uint TotalVirtual;
        /// <summary>
        /// Indicates the number of bytes of unreserved and uncommitted memory in the user mode portion of the virtual address space of the calling process.
        /// </summary>
        public uint AvailVirtual;
        [DllImport("coredll.dll")]
        private static extern void GlobalMemoryStatus(ref MemoryStatus ms);
        public static string GetMemoryStatus()
        {
            var retValue = new StringBuilder();
            MemoryStatus ms = GlobalMemoryStatus();
            retValue.AppendLine(string.Format("Memory Load {0} %", ms.MemoryLoad));
            retValue.AppendLine(string.Format("Total Phys {0} Kb", ms.TotalPhys / 1024));
            retValue.AppendLine(string.Format("Avail Phys {0} Kb", ms.AvailPhys / 1024));
            retValue.AppendLine(string.Format("Tota PFile {0} bytes", ms.TotalPageFile));
            retValue.AppendLine(string.Format("Avai PFile {0} bytes", ms.AvailPageFile));
            retValue.AppendLine(string.Format("Total Virt {0} Kb", ms.TotalVirtual / 1024));
            retValue.AppendLine(string.Format("Avail Virt {0} Kb", ms.AvailVirtual / 1024));
            return retValue.ToString();
        }
    
        public static MemoryStatus GlobalMemoryStatus()
        {
            MemoryStatus ms = new MemoryStatus();
            ms.Length = Marshal.SizeOf(ms);
            GlobalMemoryStatus(ref ms);
            return ms;
        }
        public static uint GetMemoryLoad()
        {
            var ms = GlobalMemoryStatus();
            return ms.MemoryLoad;
        }
    }
