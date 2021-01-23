    [CLSCompliant(false)]
    public class NativeMethods {
         private     MEMORYSTATUSEX msex;
         private uint _MemoryLoad;
         const int MEMORY_TIGHT_CONST = 80;
         public bool isMemoryTight()
          {
             if (_MemoryLoad > MEMORY_TIGHT_CONST )
                return true;
              else
                 return false;
         }
              public uint MemoryLoad
         {
            get { return _MemoryLoad; }
             internal set { _MemoryLoad = value; }
          }
           public NativeMethods() {
            msex = new MEMORYSTATUSEX();
            if (GlobalMemoryStatusEx(msex)) {
                      _MemoryLoad = msex.dwMemoryLoad;
                 //etc.. Repeat for other structure members        
            }
                else
                 // Use a more appropriate Exception Type. 'Exception' should almost never be thrown
                 throw new Exception("Unable to initalize the GlobalMemoryStatusEx API");
        }
        [StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto)]
        private class MEMORYSTATUSEX
        {
                  public uint dwLength;
            public uint dwMemoryLoad;
                  public ulong ullTotalPhys;
                  public ulong ullAvailPhys;
                  public ulong ullTotalPageFile;
                  public ulong ullAvailPageFile;
                  public ulong ullTotalVirtual;
                  public ulong ullAvailVirtual;
                  public ulong ullAvailExtendedVirtual;
                  public MEMORYSTATUSEX()
            {
                      this.dwLength = (uint) Marshal.SizeOf(typeof( MEMORYSTATUSEX ));
            }
        }
         [return: MarshalAs(UnmanagedType.Bool)]
         [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
         static extern bool GlobalMemoryStatusEx( [In, Out] MEMORYSTATUSEX lpBuffer);
    }
