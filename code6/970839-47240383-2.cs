    public static class Buffer
    {
        public unsafe delegate void MemcpyDelegate(byte* dest, byte* src, int len);
        public static readonly MemcpyDelegate Memcpy;
        static Buffer()
        {
            var methods = typeof (System.Buffer).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).Where(m=>m.Name == "Memcpy");
            var memcpy = methods.First(mi => mi.GetParameters().Select(p => p.ParameterType).SequenceEqual(new[] {typeof (byte*), typeof (byte*), typeof (int)}));
            Memcpy = (MemcpyDelegate) memcpy.CreateDelegate(typeof (MemcpyDelegate));
        }
    }
