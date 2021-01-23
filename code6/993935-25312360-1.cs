    var bytes = new byte[] { 1, 2, 3, 4 };
    var colors = MemCopyUtils.ByteArrayToColor32Array(bytes);
---
    public class MemCopyUtils
    {
        unsafe delegate void MemCpyDelegate(byte* dst, byte* src, int len);
        static MemCpyDelegate MemCpy;
        static MemCopyUtils()
        {
            InitMemCpy();
        }
        static void InitMemCpy()
        {
            var mi = typeof(Buffer).GetMethod(
                name: "Memcpy",
                bindingAttr: BindingFlags.NonPublic | BindingFlags.Static,
                binder:  null,
                types: new Type[] { typeof(byte*), typeof(byte*), typeof(int) },
                modifiers: null);
            MemCpy = (MemCpyDelegate)Delegate.CreateDelegate(typeof(MemCpyDelegate), mi);
        }
        public unsafe static Color32[] ByteArrayToColor32Array(byte[] bytes)
        {
            Color32[] colors = new Color32[bytes.Length / sizeof(Color32)];
            fixed (void* tempC = &colors[0])
            fixed (byte* pBytes = bytes)
            {
                byte* pColors = (byte*)tempC;
                MemCpy(pColors, pBytes, bytes.Length);
            }
            return colors;
        }
    }
