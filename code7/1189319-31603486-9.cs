    public void Iterate()
    {
        Stopwatch sw = Stopwatch.StartNew();
        // Capture a screen:
        Capture();
        TimeSpan timeToCapture = sw.Elapsed;
        // Lock both images:
        var locked1 = cur.LockBits(new Rectangle(0, 0, cur.Width, cur.Height), 
                                   ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        var locked2 = prev.LockBits(new Rectangle(0, 0, prev.Width, prev.Height),
                                    ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        try
        {
            // Xor screen:
            ApplyXor(locked2, locked1);
            TimeSpan timeToXor = sw.Elapsed;
            // Compress screen:
            int length = Compress();
            TimeSpan timeToCompress = sw.Elapsed;
            if ((++n) % 50 == 0)
            {
                Console.Write("Iteration: {0:0.00}s, {1:0.00}s, {2:0.00}s " + 
                              "{3} Kb => {4:0.0} FPS     \r",
                    timeToCapture.TotalSeconds, timeToXor.TotalSeconds, 
                    timeToCompress.TotalSeconds, length / 1024,
                    1.0 / sw.Elapsed.TotalSeconds);
            }
            // Swap buffers:
            var tmp = cur;
            cur = prev;
            prev = tmp;
        }
        finally
        {
            cur.UnlockBits(locked1);
            prev.UnlockBits(locked2);
        }
    }
