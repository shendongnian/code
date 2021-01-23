    [StructLayout(LayoutKind.Explicit)]
    public struct UInt32ToSingle
    {
        [FieldOffset(0)]
        public uint UInt32;
        [FieldOffset(0)]
        public float Single;
        [FieldOffset(0)]
        public byte Byte0;
        [FieldOffset(1)]
        public byte Byte1;
        [FieldOffset(2)]
        public byte Byte2;
        [FieldOffset(3)]
        public byte Byte3;
    }
    public static float FromByteArray(byte[] arr, int ix = 0)
    {
        uint ui = (uint)arr[ix] | ((uint)arr[ix + 1] << 8) | ((uint)arr[ix + 2] << 16) | ((uint)arr[ix + 3] << 24);
        var uitos = new UInt32ToSingle { UInt32 = ui };
        return uitos.Single;
    }
    public static byte[] ToByteArray(float f)
    {
        byte[] arr = new byte[4];
        ToByteArray(f, arr, 0);
        return arr;
    }
    public static void ToByteArray(float f, byte[] arr, int ix = 0)
    {
        var uitos = new UInt32ToSingle { Single = f };
        arr[ix] = uitos.Byte0;
        arr[ix + 1] = uitos.Byte1;
        arr[ix + 2] = uitos.Byte2;
        arr[ix + 3] = uitos.Byte3;
    }
