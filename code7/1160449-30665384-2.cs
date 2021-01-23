    /// <summary>
    /// Class that captures current thread's culture, and is able to reapply it to different one
    /// </summary>
    internal sealed class ThreadCultureHolder
    {
        private readonly CultureInfo threadCulture;
        private readonly CultureInfo threadUiCulture;
        /// <summary>
        /// Captures culture from currently running thread
        /// </summary>
        public ThreadCultureHolder()
        {
            threadCulture = Thread.CurrentThread.CurrentCulture;
            threadUiCulture = Thread.CurrentThread.CurrentUICulture;
        }
        /// <summary>
        /// Applies stored thread culture to current thread
        /// </summary>
        public void ApplyCulture()
        {
            Thread.CurrentThread.CurrentCulture = threadCulture;
            Thread.CurrentThread.CurrentUICulture = threadUiCulture;
        }
        public override string ToString()
        {
            return string.Format("{0}, UI: {1}", threadCulture.Name, threadUiCulture.Name);
        }
    }
    /// <summary>
    /// SynchronizationContext that passes around current thread's culture
    /// </summary>
    internal class CultureAwareSynchronizationContext : SynchronizationContext
    {
        private readonly ThreadCultureHolder cultureHolder;
        private readonly SynchronizationContext synchronizationImplementation;
        /// <summary>
        /// Creates default SynchronizationContext, using current(previous) SynchronizationContext 
        /// and captures culture information from currently running thread
        /// </summary>
        public CultureAwareSynchronizationContext()
            : this(Current)
        {}
        /// <summary>
        /// Uses passed SynchronizationContext (or null, in that case creates new empty SynchronizationContext) 
        /// and captures culture information from currently running thread
        /// </summary>
        /// <param name="previous"></param>
        public CultureAwareSynchronizationContext(SynchronizationContext previous)
            : this(new ThreadCultureHolder(), previous)
        {
        }
        internal CultureAwareSynchronizationContext(ThreadCultureHolder currentCultureHolder, SynchronizationContext currentSynchronizationContext)
        {
            cultureHolder = currentCultureHolder;
            synchronizationImplementation = currentSynchronizationContext ?? new SynchronizationContext();
        }
        public override void Send(SendOrPostCallback d, object state)
        {
            cultureHolder.ApplyCulture();
            synchronizationImplementation.Send(d, state);
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            synchronizationImplementation.Post(passedState =>
            {
                SetSynchronizationContext(this);
                cultureHolder.ApplyCulture();
                d.Invoke(s);
            }, state);
        }
        public override SynchronizationContext CreateCopy()
        {
            return new CultureAwareSynchronizationContext(cultureHolder, synchronizationImplementation.CreateCopy());
        }
        public override string ToString()
        {
            return string.Format("CultureAwareSynchronizationContext: {0}", cultureHolder);
        }
    }
