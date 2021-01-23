    using System.Runtime.InteropServices;
    ...
        public static double LuaRandom() {
            const int RAND_MAX = 0x7fff;
            return (double)(rand() % RAND_MAX) / RAND_MAX;
        }
        public static void LuaRandomSeed(int seed) {
            srand(seed);
        }
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int rand();
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern void srand(int seed);
