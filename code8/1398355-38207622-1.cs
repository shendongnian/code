        public void Listen()
        {
            receiveClient.BeginReceive(new AsyncCallback(ProcessIncoming), null);
        }
        private void ProcessIncoming(IAsyncResult res)
        {
             byte[] rec_bytes = receiveClient.EndReceive(res, ref rec_ep);
             receiveClient.BeginReceive(new AsyncCallback(ProcessIncoming), null);
             PacketReceivedEventArgs args = new PacketReceivedEventArgs();
             args.IP = rec_ep.Address;
             args.Port = rec_ep.Port;
             args.Data = rec_bytes;
             OnPacketReceived(args);
        }
        protected virtual void OnPacketReceived(PacketReceivedEventArgs e)
        {
            EventHandler<PacketReceivedEventArgs> handler = PacketReceived;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        public event EventHandler<PacketReceivedEventArgs> PacketReceived;
        public class PacketReceivedEventArgs : EventArgs
        {
             public byte[] Data { get; set; }
             public IPAddress IP { get; set; }
             public int Port { get; set; }
        }
