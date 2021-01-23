    [StructLayout(LayoutKind.Explicit)]
    public struct UInt32ToSingle
    {
        [FieldOffset(0)]
        public uint UInt32;
        [FieldOffset(0)]
        public float Single;
    }
    public static float FromByteArray(byte[] arr, int ix = 0)
    {
        uint ui = (uint)arr[ix] | ((uint)arr[ix + 1] << 8) | ((uint)arr[ix + 2] << 16) | ((uint)arr[ix + 3] << 24);
        var uitos = new UInt32ToSingle { UInt32 = ui };
        return uitos.Single;
    }
