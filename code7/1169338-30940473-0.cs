    internal class ServiceContainer
    {
        /// <summary>
        /// Process service which runs the monitor
        /// </summary>
        public IService ServiceProcess { get; private set; }
        /// <summary>
        /// Cancellation token used to cancel the operation
        /// </summary>
        public CancellationTokenSource CancelTokenSource { get; private set; }
        internal ProcessContainer(IService plugin)
        {
            this.PluginProcess = plugin;
            CancelTokenSource = new CancellationTokenSource();
        }
    }
