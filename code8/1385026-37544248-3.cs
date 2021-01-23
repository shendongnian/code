<!-- -->
    class Program
    {
        static void Main(string[] args)
        {
           // Open the volume handle using CreateFile()
           SafeFileHandle sfh = ...
    
           // Prepare to obtain disk extents.
           // NOTE: This code assumes you only have one disk!
           NativeMethods.VOLUME_DISK_EXTENTS vde           = new NativeMethods.VOLUME_DISK_EXTENTS();
           UInt32                            outBufferSize = (UInt32)Marshal.SizeOf(vde);
           IntPtr                            outBuffer     = Marshal.AllocHGlobal((int)outBufferSize);
           UInt32                            bytesReturned = 0;
           if (NativeMethods.DeviceIoControl(sfh,
                                             NativeMethods.IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS,
                                             IntPtr.Zero,
                                             0,
                                             outBuffer,
                                             outBufferSize,
                                             out bytesReturned,
                                             IntPtr.Zero))
           {
              // The call succeeded, so marshal the data back to a
              // form usable from managed code.
              Marshal.PtrToStructure(outBuffer, vde);
    
              // Do something with vde.Extents here...e.g.
              Console.WriteLine("DiskNumber: {0}\nStartingOffset: {1}\nExtentLength: {2}",
                                vde.Extents.DiskNumber,
                                vde.Extents.StartingOffset,
                                vde.Extents.ExtentLength);
           }
           Marshal.FreeHGlobal(outBuffer);
        }
    }
