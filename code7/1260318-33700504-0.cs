        //Functions to turn byte arrays to structs. 
        public static byte[] RawSerialize<T>(T frqStruct)
        where T : struct
        {
            int rawsize = Marshal.SizeOf<T>();
            IntPtr i = IntPtr.Zero;
            try
            {
                i = Marshal.AllocHGlobal(rawsize);
                Marshal.StructureToPtr<T>(frqStruct, i, false);
                byte[] rawdatas = new byte[rawsize];
                Marshal.Copy(i, rawdatas, 0, rawsize);
                return rawdatas;
            }
            finally
            {
                if (i != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(i);
                }
            }
        }
        public static T RawDeserialize<T>(byte[] bytearray)
        where T : struct
        {
            int len = Marshal.SizeOf<T>();
            IntPtr i = IntPtr.Zero;
            try
            {
                i = Marshal.AllocHGlobal(len);
                Marshal.Copy(bytearray, 0, i, len);
                return Marshal.PtrToStructure<T>(i);
            }
            finally
            {
                if (i != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(i);
                }
            }
        }
