        PeerFinder.DisplayName = "Doru " + Guid.NewGuid().ToString();
        PeerFinder.ConnectionRequested += PeerFinder_ConnectionRequested;
            
        PeerFinder.Start();
        private async void PeerFinder_ConnectionRequested(object sender, ConnectionRequestedEventArgs args)
        {
            PeerInformation peer = args.PeerInformation;
            StreamSocket socket = await PeerFinder.ConnectAsync(peer);
        }
