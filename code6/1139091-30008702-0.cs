        struct MyStruct
        {
            private byte _byte1;
            private byte _byte2;
            private string _string1;
            public byte Byte1 { get { return _byte1; } }
            public byte Byte2 { get { return _byte2; } }
            public string String1 { get { return _string1; } }
            public MyStruct(byte byte1, byte byte2, string string1)
            {
                _byte1 = byte1;
                _byte2 = byte2;
                _string1 = string1;
            }
        }
