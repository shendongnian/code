        private class AsyncState
        {
            public byte[] Buffer { get; set; }
            public NetworkStream NetworkStream { get; set; }
            public CancellationTokenSource CancellationTokenSource { get; set; }
        }
