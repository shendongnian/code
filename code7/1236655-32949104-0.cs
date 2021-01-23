    [Serializable]
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack=1)]
    public struct USSDContinueModel
    {
        [MarshalAs(UnmanagedType.U4)]
        public uint Command_Length;
        [MarshalAs(UnmanagedType.U4)]
        public uint Command_ID;
        [MarshalAs(UnmanagedType.U4)]
        public uint Command_Status;
        [MarshalAs(UnmanagedType.U4)]
        public uint Sender_ID;
        [MarshalAs(UnmanagedType.U4)]
        public uint Receiver_ID;
        [MarshalAs(UnmanagedType.U1)]
        public byte Ussd_Version;
        [MarshalAs(UnmanagedType.U1)]
        public byte Ussd_Op_Type;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string MsIsdn;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string Service_Code;
        [MarshalAs(UnmanagedType.U1)]
        public byte Code_Scheme;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 182)]
        public string Ussd_Content;
        // Calling this method will return a byte array with the contents
        // of the struct ready to be sent via the tcp socket.
        public byte[] Serialize()
        {
            // allocate a byte array for the struct data
            var buffer = new byte[Marshal.SizeOf(typeof(USSDContinueModel))];
            // Allocate a GCHandle and get the array pointer
            var gch = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var pBuffer = gch.AddrOfPinnedObject();
            // copy data from struct to array and unpin the gc pointer
            Marshal.StructureToPtr(this, pBuffer, false);
            gch.Free();
            return buffer;
        }
        // this method will deserialize a byte array into the struct.
        public void Deserialize(ref byte[] data)
        {
            var gch = GCHandle.Alloc(data, GCHandleType.Pinned);
            this = (USSDContinueModel)Marshal.PtrToStructure(gch.AddrOfPinnedObject(), typeof(USSDContinueModel));
            gch.Free();
        }
    }
