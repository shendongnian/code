    [System.Runtime.InteropServices.DllImport("WBTRV32.dll", CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        static extern short BTRCALL(ushort operation,
        [System.Runtime.InteropServices.MarshalAs  (System.Runtime.InteropServices.UnmanagedType.LPArray, SizeConst = 128)] byte[] posBlk,
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Struct, SizeConst = 255)]
        ref RecordBuffer databuffer,
        ref int dataLength,
        [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPArray, SizeConst = 255)] char[] keyBffer,
        ushort keyLength, ushort keyNum);
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, Pack = 1, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
        public struct RecordBuffer
        {
            public short docType;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 2500)]
            public char[] docDescPlural;
            public short sorting;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValArray, SizeConst = 2500)]
            public char[] docDescSingle;
            public short copyOtherThanSrc;
            public double defaultNotebookNo;
        }
    private void PopulateAllRecords(string fileName)
        {
            byte[] positionBlock = new byte[128];
            char[] fileNameArray = fileName.ToCharArray();
            // Open file
            RecordBuffer dataBuffer = new RecordBuffer();
            int bufferLength = System.Runtime.InteropServices.Marshal.SizeOf(dataBuffer);
            short status = (short)BTRCALL((ushort)OPCODE.BOPEN, positionBlock, ref dataBuffer, ref bufferLength, fileNameArray, 0, 0);
            if (status == 0)
            {
             .....
             }
       }
