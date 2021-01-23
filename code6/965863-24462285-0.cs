        private const int NumLines = 1024;
        private const int LineLength = 768*3;
        private const int ArraySize = NumLines*LineLength;
        [DllImport("Kernel32.dll", EntryPoint = "RtlMoveMemory", SetLastError = false)]
        private static unsafe extern void MoveMemory(void* dest, void* src, int size);
        unsafe public void Test()
        {
            // initialize a big array to test the copy
            var source = Enumerable.Range(0, ArraySize).Select(x => (byte)x).ToArray();
            var dest = new byte[ArraySize];
            fixed (byte* pSource = source, pDest = dest)
            {
                // test single threaded
                // do it once for the JIT
                Console.WriteLine("Testing single threaded...");
                MoveSingleThread(pSource, pDest, NumLines, LineLength);
                // Okay, time it.
                var sw = Stopwatch.StartNew();
                MoveSingleThread(pSource, pDest, NumLines, LineLength);
                sw.Stop();
                Console.WriteLine("Single threaded: {0:N0} ticks", sw.ElapsedTicks);
                var singleTicks = sw.ElapsedTicks;
                Console.WriteLine("Testing parallel");
                // do it once for JIT
                MoveParallel(pSource, pDest, NumLines, LineLength);
                sw = Stopwatch.StartNew();
                MoveParallel(pSource, pDest, NumLines, LineLength);
                sw.Stop();
                Console.WriteLine("Parallel: {0:N0} ticks", sw.ElapsedTicks);
                var diff = sw.ElapsedTicks - singleTicks;
                var pct = (double) sw.ElapsedTicks/singleTicks;
                Console.WriteLine("Difference: {0:N0} ticks {1:P2}", diff, pct);
            }
        }
        private unsafe void MoveSingleThread(byte* source, byte* dest, int nLines, int lineLength)
        {
            var srcPtr = source;
            var dstPtr = dest;
            for (int y = 0; y < nLines; ++y)
            {
                MoveMemory(dstPtr, srcPtr, lineLength);
                srcPtr += lineLength;
                dstPtr += lineLength;
            }
        }
        unsafe void MoveParallel(byte* source, byte* dest, int nLines, int lineLength)
        {
            Parallel.For(0, nLines, (y) =>
            {
                byte* srcPtr = source + y * lineLength;
                byte* dstPtr = dest + y * lineLength;
                MoveMemory(dstPtr, srcPtr, lineLength);
            });
        }
