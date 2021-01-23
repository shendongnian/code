    /// <summary>
    /// Wraps the Application Dispatcher.
    /// </summary>
    public class DefaultDispatcher : IDispatcherFacade
    {
        /// <summary>
        /// Forwards the BeginInvoke to the current application's <see cref="Dispatcher"/>.
        /// </summary>
        /// <param name="method">Method to be invoked.</param>
        /// <param name="arg">Arguments to pass to the invoked method.</param>
        public void BeginInvoke(Delegate method, object arg)
        {
            if (Application.Current != null)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, method, arg);
            }
        }
    }
