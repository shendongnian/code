    public class Volume
    {
        public Volume(string path)
        {
            Path = path;
            ulong freeBytesAvail, totalBytes, totalFreeBytes;
            if (GetDiskFreeSpaceEx(path, out freeBytesAvail, out totalBytes, out totalFreeBytes))
            {
                FreeBytesAvailable = freeBytesAvail;
                TotalNumberOfBytes = totalBytes;
                TotalNumberOfFreeBytes = totalFreeBytes;
            }
        }
        public string Path { get; private set; }
        public ulong FreeBytesAvailable { get; private set; }
        public ulong TotalNumberOfBytes { get; private set; }     
        public ulong TotalNumberOfFreeBytes { get; private set; }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool GetDiskFreeSpaceEx([MarshalAs(UnmanagedType.LPStr)]string volumeName, out ulong freeBytesAvail,
            out ulong totalBytes, out ulong totalFreeBytes);
    }
