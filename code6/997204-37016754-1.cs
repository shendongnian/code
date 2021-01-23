    #region AddressOf
        /// <summary>
        /// Provides the current address of the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static System.IntPtr AddressOf(object obj)
        {
            if (obj == null) return System.IntPtr.Zero;
            System.TypedReference reference = __makeref(obj);
            System.TypedReference* pRef = &reference;
            return (System.IntPtr)pRef; //(&pRef)
        }
        /// <summary>
        /// Provides the current address of the given element
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static System.IntPtr AddressOf<T>(T t)
            //refember ReferenceTypes are references to the CLRHeader
            //where TOriginal : struct
        {
            System.TypedReference reference = __makeref(t);
            return *(System.IntPtr*)(&reference);
        }
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        static System.IntPtr AddressOfRef<T>(ref T t)
        //refember ReferenceTypes are references to the CLRHeader
        //where TOriginal : struct
        {
            System.TypedReference reference = __makeref(t);
            System.TypedReference* pRef = &reference;
            return (System.IntPtr)pRef; //(&pRef)
        }
        /// <summary>
        /// Returns the unmanaged address of the given array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns><see cref="IntPtr.Zero"/> if null, otherwise the address of the array</returns>
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        public static System.IntPtr AddressOfByteArray(byte[] array)
        {
            if (array == null) return System.IntPtr.Zero;
            fixed (byte* ptr = array)
                return (System.IntPtr)(ptr - 2 * sizeof(void*)); //Todo staticaly determine size of void?
        }
        #endregion
