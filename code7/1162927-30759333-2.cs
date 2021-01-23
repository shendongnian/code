        public static unsafe string BytesToString(byte* bytes, int len)
        {
            return new string((sbyte*)bytes, 0, len).Trim(new char[] { ' ' }); // trim trailing spaces (but keep newline characters)
        }
        [StructLayout(LayoutKind.Explicit, Size = 127 + 2 + 149 + 2 + 10)]
        unsafe struct USRRECORD_ANSI
        {
            [FieldOffset(0)]
            public fixed byte Name[127];
            [FieldOffset(127)]
            public fixed byte s1[2];
            [FieldOffset(127 + 2)]
            public fixed byte MailBox[149];
            [FieldOffset(127 + 2 + 149)]
            public fixed byte s2[2];
            [FieldOffset(127 + 2 + 149 + 2)]
            public fixed byte RouteID[10];
         }
