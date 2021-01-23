    /// <summary>
    /// Prism's UI thread option works by invoking Post on the current synchronization context.
    /// When we do that, base.Post actually looses SynchronizationContext.Current
    /// because the work has been delegated to ThreadPool.QueueUserWorkItem.
    /// This implementation makes our async-intended call behave synchronously,
    /// so we can preserve and verify sync contexts for callbacks during our unit tests.
    /// </summary>
    internal class MockSynchronizationContext : SynchronizationContext
    {
        public override void Post(SendOrPostCallback d, object state)
        {
            d(state);
        }
    }
