    public interface MIB_OWNER_PID
    {
       public void update (uint state,uint localaddr, byte[] localport, /*etc*/)
       public uint localAddress { get; set; }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MIB_TCPROW_OWNER_PID : MIB_OWNER_PID
    {
       public uint state;
       public uint localAddr;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
       public byte[] localPort;
       public uint remoteAddr;
       [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
       public byte[] remotePort;
       public uint owningPid;
       public void update (uint state,uint localaddr, byte[] localport, /*etc*/)
       {
       }
       public uint localAddress 
       {
          get { return localAddr;} 
          set { localAddr = value}
        }
    }
