    // THIS ISN'T TESTED AND IS WRITTEN HERE, SO MIND THE SYNTAX, THIS MIGHT NOT COMPILE !!
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
