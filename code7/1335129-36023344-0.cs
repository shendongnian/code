    private Task<TestResult> GenericServiceWarmUp<TService>(string serviceEndPoint) where TService : IDisposable
    {
        return Task<TestResult>.Factory.StartNew(() =>
        {
            using (var service = Activator.CreateInstance(typeof(TService), serviceEndPoint))
            {
                // do some stuff with generic client
            }
        });
    }
