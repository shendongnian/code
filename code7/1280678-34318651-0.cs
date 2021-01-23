    public static class BackgroundTaskExecuter
    {
        public static void ResolveAndConsume<T>(Action<T> consumeService) where T : IService
        {
            using (var service = IocManager.Instance.ResolveAsDisposable<T>())
            {
                consumeService(service);
            }
        }
    }
