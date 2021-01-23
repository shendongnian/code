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
        private int sizeOfT;
        /// <summary>
        /// Copy Array to Pointer
        /// </summary>
        public void ArrayToPointer()
        {
            if (Array == null || Pointer == IntPtr.Zero)
            {
                return;
            }
            int length = (int)Math.Min(PointerElementCount, Array.Length);
            int byteCount = length * sizeOfT;
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
                    int byteCount2 = byteCount + (sizeOfT * (PointerElementCount - Array.Length));
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
            if (Pointer == IntPtr.Zero)
            {
                return;
            }
            Array = new T[PointerElementCount];
            GCHandle handle = GCHandle.Alloc(Array, GCHandleType.Pinned);
            int byteCount = Array.Length * sizeOfT;
            unsafe
            {
                for (int i = 0; i < byteCount; i++)
                {
                    *(((byte*)handle.AddrOfPinnedObject()) + i) = *(((byte*)Pointer) + i);
                }
            }
            handle.Free();
        }
        public StructPointer()
        {
            sizeOfT = Marshal.SizeOf(typeof(T));
        }
        /// <summary>
        /// Constructor. Copies pointer to Array.
        /// </summary>
        /// <param name="pointer">Pointer</param>
        /// <param name="length">Number of elements in pointer</param>
        public StructPointer(IntPtr pointer, int length)
        {
            sizeOfT = Marshal.SizeOf(typeof(T));
            Pointer = pointer;
            PointerElementCount = length; // number of elements in pointer, not number of bytes
            ArrayFromPointer();
        }
    }
