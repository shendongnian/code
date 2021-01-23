    public static class GlobalModule
    {
        public static ILogger Logger;
        public static ITaskScheduler TaskScheduler;
        public static void StopScheduler()
        {
            if (TaskScheduler == null) return;
            try
            {
                TaskScheduler.Stop();
            }
            catch (Exception ex)
            {
                if (Logger != null)
                {
                    Logger.Error("TaskScheduler.Stop()", ex);
                }
            }
        }
    }
