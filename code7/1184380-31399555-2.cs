    /// <summary>
    /// Prism's UI thread option works by invoking Post on the current synchronization context.
    /// When we do that, we actually loose SynchronizationContext.Current.
    /// This implementation makes our async-intended call behave synchronously,
    /// so we can verify sync contexts for callbacks during our unit tests.
    /// </summary>
    internal class MockSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            d(state);
        }
    }
