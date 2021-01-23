    using System;
    using System.Runtime.InteropServices;
    using Mono.Unix.Native;
    static class Test
    {
        static int WaitForInterrupt()
        {
            byte[] buffer = new byte[4];
			GCHandle handle = GCHandle.Alloc(buffer, GCHandleType.Pinned);
			IntPtr pBuffer = handle.AddrOfPinnedObject();
            int fd = Syscall.open("/dev/uioX", OpenFlags.O_RDONLY);
			long result = Syscall.read(fd, pBuffer, Convert.ToUInt64(buffer.Length));
            Syscall.close(fd);
            handle.Free();
            return BitConverter.ToInt32(buffer, 0);
        }
    }
