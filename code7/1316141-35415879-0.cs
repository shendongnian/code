    public class StructPointer<T> where T : struct
    {
        public IntPtr pointer { get; set; }
        public int Size { get; set; }
        public T[] Array { get; set; }
    
        public void ArrayToPointer()
        {
            int length = (int)Math.Min(Size, Array.Length);
            int byteCount = Array.Length * Marshal.SizeOf<T>();
            GCHandle handle = GCHandle.Alloc(Array, GCHandleType.Pinned);
            unsafe
            {
                for (int i = 0; i < byteCount; i++)
                {
                    *(((byte*)pointer) + i) = *(((byte*)handle.AddrOfPinnedObject()) + i);
                }
            }
            handle.Free();
            unsafe
            {
                int byteCount2 = Size * byteCount;
                for (int i = byteCount; i < byteCount2; i++)
                {
                    *(((byte*)pointer) + i) = 0;
                }
            }
        }
    
        public void ArrayFromPointer()
        {
            Array = new T[Size];
            GCHandle handle = GCHandle.Alloc(Array, GCHandleType.Pinned);
            int byteCount = Array.Length * Marshal.SizeOf<T>();
            unsafe
            {
                for (int i = 0; i < byteCount; i++)
                {
                    *(((byte*)handle.AddrOfPinnedObject()) + i) = *(((byte*)pointer) + i);
                }
            }
            handle.Free();
        }
    
        public StructPointer(IntPtr pointer, int size)
        {
            this.pointer = pointer;
            Size = size;
            ArrayFromPointer();
        }
    }
