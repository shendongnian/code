public class Test
{
    private AutoResetEvent _eventWaitThread = new AutoResetEvent(false);
    private void Job()
    {
        Action act = () =>
        {
            try
            {
                // do work...
            }
            finally
            {
                _eventWaitThread.Set();
            }
        };
        ThreadPool.QueueUserWorkItem(x => act());
        _eventWaitThread.WaitOne(10 * 1000 * 60);
    }
}
