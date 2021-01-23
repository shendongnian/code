    private static void Stop(NancyHost host)
        {
            GlobalModule.StopScheduler();
            if (_syncContext == SynchronizationContext.Current)
            {
                host.Dispose();
            }
            else
            {
                _syncContext.Post((state) =>
                {
                    host.Dispose();
                }
                , null);
            }
            try
            {
                host.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: {0}\r\n Stack Trace: {1}", ex.Message, ex.StackTrace));
            }
        }
