        NetworkChange.NetworkAvailabilityChanged += NetworkChange_NetworkAvailabilityChanged;
        using Microsoft.Win32;
        private void NetworkChange_NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {            
            _connectionStatus = !e.IsAvailable ? ConnectionStatus.Unplugged : ConnectionStatus.Connected;
        }
