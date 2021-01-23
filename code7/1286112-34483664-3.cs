    public static class ByteArrayCache
    {
        [ThreadStatic]
        private static byte[] cachedInstance;
        private const int maxArraySize = 1024;
        public static byte[] Acquire(int size)
        {
            if (size <= maxArraySize)
            {
                byte[] instance = cachedInstance;
                if (cachedInstance != null && cachedInstance.Length >= size)
                {
                    cachedInstance = null;
                    return instance;
                }
            }
            return new byte[size];
        }
        public static void Release(byte[] array)
        {
            if ((array != null && array.Length <= maxArraySize) &&
                (cachedInstance == null || cachedInstance.Length < array.Length))
            {
                cachedInstance = array;
            }
        }
    }
