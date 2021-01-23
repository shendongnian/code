    public static class TestHelper
    {
        public static readonly TimeSpan DefaultTimeout = TimeSpan.FromMilliseconds(1000);
        public static IBus DefaultMessageBus
        {
            get
            {
                return BusSetup.StartWith<Conservative>().Construct();
            }
        }
        public static async Task<bool> ContainsEvents<T>(this Task<IList<T>> eventBufferTask)
        {
            return (await eventBufferTask).Any();
        }
    }
    public static class ObservableExtensions
    {
        public static Task<T> WaitForEmission<T>(this IObservable<T> observable)
        {
            return observable.WaitForEmission(TestHelper.DefaultTimeout);
        }
        public static Task<T> WaitForEmission<T>(this IObservable<T> observable, TimeSpan timeout)
        {
            return observable.FirstAsync().Timeout(timeout).ToTask();
        }
        public static Task<IList<T>> BufferEmissions<T>(this IObservable<T> observable)
        {
            return observable.BufferEmissions(TestHelper.DefaultTimeout);
        }
        public static Task<IList<T>> BufferEmissions<T>(this IObservable<T> observable, TimeSpan bufferWindow)
        {
            return observable.Buffer(bufferWindow).FirstAsync().ToTask();
        }
    }
