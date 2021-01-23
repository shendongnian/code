    InitMemCpy(); //Call this only once
    var bytes = new byte[] {1,2,3,4 };
    var colors = ByteArrayColor32Array(bytes);
---
    unsafe void InitMemCpy()
    {
        var mi = typeof(Buffer).GetMethod("Memcpy",
            BindingFlags.NonPublic | BindingFlags.Static,
            null,
            new Type[] { typeof(byte*), typeof(byte*), typeof(int) },
            null);
        MemCpy = (MemCpyDelegate)Delegate.CreateDelegate(typeof(MemCpyDelegate), mi);
    }
    unsafe delegate void MemCpyDelegate(byte* dst, byte* src, int len);
    static MemCpyDelegate MemCpy;
    private unsafe static Color32[] ByteArrayColor32Array(byte[] bytes)
    {
        Color32[] colors = new Color32[bytes.Length / sizeof(Color32)];
        fixed ( void* tempC = &colors[0] )
        fixed (byte* pBytes = bytes)
        {
            byte* pColors = (byte*)tempC;
            MemCpy(pColors, pBytes, bytes.Length);
        }
        return colors;
    }
