    public class MyObject
    {
        // normally you should use locks to access fields from different threads
        // but if you just set a bool from one thread and read it from another,
        // then it is enough to use a volatile field.
        private volatile bool isCancelRequested;
        // this will be called from the main thread
        public void CancelWork()
        {
            isCancelRequested = true;
        }
        // This method is called from the worker thread.
        public void DoWork()
        {
            // Make sure you poll the isCancelRequested field often enough to
            // react to the cancellation as soon as possible.
            while (!isCancelRequested && ...)
            {
                // ...
            }
        }
    }
