    private Task<TestResult> GenericServiceWarmUp<TService>()
    where TService : IDisposable
    {
        return Task<TestResult>.Factory.StartNew(() =>
        {
            using (var service = (TService)Activator.CreateInstance(typeof(TService), serviceEndPoint))
            {
                // do some stuff with generic client
            }
        });
    }
