    private Task<TestResult> GenericServiceWarmUp<TService>(string serviceEndPoint)
    where TService : IDisposable, new()
    {
        return Task<TestResult>.Factory.StartNew(() =>
        {
            using (var service = new TService())
            {
                // do some stuff with generic client
            }
        });
    }
