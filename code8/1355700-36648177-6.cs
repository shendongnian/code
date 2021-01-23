    using System;
    using System.Runtime.InteropServices;
    using Mono.Unix.Native;
    static class Test
    {
        static int WaitForInterrupt()
        {
            byte[] buffer = new byte[4];
			GCHandle hBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            int fd = Syscall.open("/dev/uioX", OpenFlags.O_RDONLY);
			long result = Syscall.read(fd, hBuffer.AddrOfPinnedObject(), Convert.ToUInt64(buffer.Length));
            Syscall.close(fd);
            hBuffer.Free();
            return BitConverter.ToInt32(buffer, 0);
        }
    }
