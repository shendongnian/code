    internal static class NativeMethods
    {
       internal const UInt32 IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x00560000;
    
       [StructLayout(LayoutKind.Sequential)]
       internal class DISK_EXTENT
       {
          public UInt32 DiskNumber;
          public Int64  StartingOffset;
          public Int64  ExtentLength;
       }
    
       [StructLayout(LayoutKind.Sequential)]
       internal class VOLUME_DISK_EXTENTS
       {
          public UInt32      NumberOfDiskExtents;
          public DISK_EXTENT Extents;
       }
    
       [DllImport("kernel32", SetLastError = true)]
       [return: MarshalAs(UnmanagedType.Bool)]                             
       internal static extern bool DeviceIoControl(SafeFileHandle hDevice,
                                                   UInt32         ioControlCode,
                                                   IntPtr         inBuffer,
                                                   UInt32         inBufferSize,
                                                   IntPtr         outBuffer,
                                                   UInt32         outBufferSize,
                                                   out UInt32     bytesReturned,
                                                   IntPtr         overlapped);
    }
