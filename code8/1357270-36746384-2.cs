        /// <summary>
        /// Create a connection using a list of hostnames. The first reachable
        /// hostname will be used initially. Subsequent hostname picks are determined
        /// by the <see cref="IHostnameSelector" /> configured.
        /// </summary>
        /// <param name="hostnames">
        /// List of hostnames to use for the initial
        /// connection and recovery.
        /// </param>
        /// <returns>Open connection</returns>
        /// <exception cref="BrokerUnreachableException">
        /// When no hostname was reachable.
        /// </exception>
        public IConnection CreateConnection(IList<string> hostnames)
        {
            return CreateConnection(hostnames, null);
        }
