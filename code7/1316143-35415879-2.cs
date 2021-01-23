    public class StructPointer<T> where T : struct
    {
        /// <summary>
        /// Pointer
        /// </summary>
        public IntPtr Pointer { get; set; }
        /// <summary>
        /// Number of elements in pointer
        /// </summary>
        public int PointerElementCount { get; set; }
        /// <summary>
        /// Array
        /// </summary>
        public T[] Array { get; set; }
        /// <summary>
        /// Copy Array to Pointer
        /// </summary>
        public void ArrayToPointer()
        {
            int length = (int)Math.Min(PointerElementCount, Array.Length);
            int byteCount = length * Marshal.SizeOf(typeof(T));
            GCHandle handle = GCHandle.Alloc(Array, GCHandleType.Pinned);
            unsafe
            {
                for (int i = 0; i < byteCount; i++)
                {
                    *(((byte*)Pointer) + i) = *(((byte*)handle.AddrOfPinnedObject()) + i);
                }
            }
            handle.Free();
            if (PointerElementCount > Array.Length)
            {
                unsafe
                {
                    int byteCount2 = byteCount + (SizeOf(typeof(T)) * (PointerElementCount - Array.Length));
                    for (int i = byteCount; i < byteCount2; i++)
                    {
                        *(((byte*)Pointer) + i) = 0;
                    }
                }
            }
        }
        /// <summary>
        /// Copy Pointer to Array
        /// </summary>
        public void ArrayFromPointer()
        {
            Array = new T[PointerElementCount];
            GCHandle handle = GCHandle.Alloc(Array, GCHandleType.Pinned);
            int byteCount = Array.Length * SizeOf(typeof(T));
            unsafe
            {
                for (int i = 0; i < byteCount; i++)
                {
                    *(((byte*)handle.AddrOfPinnedObject()) + i) = *(((byte*)Pointer) + i);
                }
            }
            handle.Free();
        }
        /// <summary>
        /// Constructor. Copies pointer to Array.
        /// </summary>
        /// <param name="pointer">Pointer</param>
        /// <param name="length">Number of elements in pointer</param>
        public StructPointer(IntPtr pointer, int length)
        {
            Pointer = pointer;
            PointerElementCount = length; // number of elements in pointer, not number of bytes
            ArrayFromPointer();
        }
    }
