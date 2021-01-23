    public static class BackgroundTaskExecuter
    {
        public static void ResolveAndConsume<T>(Action<T> consumeService)
        {
            // Consider applying constraint to the <T> to 
            // match the constraint of ResolveAsDisposable<T>
            using (var service = IocManager.Instance.ResolveAsDisposable<T>())
            {
                consumeService(service);
            }
        }
    }
