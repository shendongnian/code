    unsafe
    {
        Stopwatch watch = new Stopwatch();
        watch.Start();
        try
        {
             ....
             return new Point(x,y); // To return x,y corrdinates
        }
        finally
        {
            bitmap.UnlockBits(data);
            watch.Stop();
        }
    }
