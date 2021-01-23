    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    class Program {
        static unsafe void Main(string[] args) {
            var mmf = System.IO.MemoryMappedFiles.MemoryMappedFile.CreateNew("test", 42);
            var view = mmf.CreateViewAccessor();
            byte* poke = null;
            view.SafeMemoryMappedViewHandle.AcquirePointer(ref poke);
            *(int*)poke = 0x12345678;
            Debug.Assert(*poke == 0x78);
            Debug.Assert(*(poke + 1) == 0x56);
            Debug.Assert(*(short*)poke == 0x5678);
            Debug.Assert(*((short*)poke + 1) == 0x1234);
            Debug.Assert(*(short*)(poke + 2) == 0x1234);
            IntPtr ipoke = (IntPtr)poke;
            Debug.Assert(Marshal.ReadInt32(ipoke) == 0x12345678);
            *(poke + 1) = 0xab;
            Debug.Assert(Marshal.ReadInt32(ipoke) == 0x1234ab78);
        }
    }
