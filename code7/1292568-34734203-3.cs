        for (long i = 0; i < 5000000000; i++)
               {
                   MaybeGCMeHere(); // new callsite
                   a = Math.Sqrt(a) + Math.Sqrt(a + 1) + i;
                   if (i % 1000000000 == 0) { Debug.WriteLine($"Threadpool -> a value = {a} got in {watch.ElapsedMilliseconds} ms"); watch.Restart(); };
        }
    ...
        [MethodImpl(MethodImplOptions.NoInlining)] // need this so the callsite isn’t optimized away
        private void MaybeGCMeHere()
        {
        }
