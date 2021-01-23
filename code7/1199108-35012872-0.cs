        /// <summary>
        /// Event is triggered when the peer is disconnecting
        /// </summary>
        public event DisconnectHandler OnDisconnect;
        public delegate void DisconnectHandler(Peer p);
