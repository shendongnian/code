    class Program
    {
        static void Main(string[] args)
        {
            MYSTRUCT1 s = new MYSTRUCT1();
            s.a = 1; s.b = 2; s.c = 3;
            byte[] buffer = StructToByteArray(s);
            MYSTRUCT1 ss = new MYSTRUCT1();
            ss = (MYSTRUCT1)ByteArrayToAnyStruct(ss, buffer); 
        }
    
        struct MYSTRUCT1 { public int a; public int b; public int c; }
        struct MYSTRUCT2 { public int a; public string b; }
    
        static byte[] StructToByteArray(object s)
        {
            byte[] data = new byte[Marshal.SizeOf(s)];
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(s));
            Marshal.StructureToPtr(s, ptr, true);
            Marshal.Copy(ptr, data, 0, data.Length);
            return data;
        }
        static object ByteArrayToAnyStruct(object s, byte[] buffer)
        {
            IntPtr ptr = Marshal.AllocHGlobal(buffer.Length);
            Marshal.Copy(buffer, 0, ptr, buffer.Length);
            s = Marshal.PtrToStructure(ptr, s.GetType());
            Marshal.FreeHGlobal(ptr);
            return s;
        }
    }
