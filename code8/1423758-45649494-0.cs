        public Binding GetBinding()
        {
            var binding = new NetNamedPipeBinding
            {
                OpenTimeout = TimeSpan.FromMinutes(15),
                SendTimeout = TimeSpan.FromMinutes(15),
                CloseTimeout = TimeSpan.FromMinutes(15),
                MaxConnections = 200,
                MaxBufferSize = int.MaxValue,
                MaxReceivedMessageSize = int.MaxValue,
                MaxBufferPoolSize = int.MaxValue,
                TransactionFlow = false,
                TransactionProtocol = TransactionProtocol.WSAtomicTransaction11,
                TransferMode = TransferMode.StreamedRequest,
                HostNameComparisonMode = HostNameComparisonMode.WeakWildcard
            };
            binding.Security.Transport.ProtectionLevel = ProtectionLevel.None;
            return binding;
        }
