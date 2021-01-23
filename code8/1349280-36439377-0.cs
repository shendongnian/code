    [StructLayout(LayoutKind.Explicit)]
    public struct Color32Bytes
    {
        [FieldOffset(0)]
        public byte[] byteArray;
        [FieldOffset(0)]
        public Color32[] colors;
    }
    Color32Bytes data = new Color32Bytes();
    data.byteArray = new byte[width * height * bytesPerPixel];
    data.colors = new Color32[width * height];
