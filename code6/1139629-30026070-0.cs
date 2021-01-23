     AutoResetEvent handle = new AutoResetEvent(true);
     for (long key = 0; key < 5; key++)
     {
        var processingThread = new Thread(() => 
            {
               handle.Wait(); 
               Setup(key)
            } );
        processingThread.Start();
     }
     handle.Set();
