    public partial class NativeConstants {
        
        /// CAN_MSG_DATA_LEN -> 100
        public const int CAN_MSG_DATA_LEN = 100;
    }
    
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet=System.Runtime.InteropServices.CharSet.Ansi)]
    public struct can_msg {
        
        /// unsigned short
        public ushort ide;
        
        /// unsigned int
        public uint id;
        
        /// unsigned short
        public ushort dlc;
        
        /// unsigned char[100]
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst=100)]
        public string data;
        
        /// unsigned short
        public ushort rtr;
    }
    
    public partial class NativeMethods {
        
        /// Return Type: int
        ///msg: can_msg_t*
        [System.Runtime.InteropServices.DllImportAttribute("<Unknown>", EntryPoint="CAN_Transmission")]
    public static extern  int CAN_Transmission(ref can_msg msg) ;
    
    }
