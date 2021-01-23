    public class WSDiscoveryResponse
    {
        private readonly string
            _content,
            _remotePort;
    
        private readonly HostName
            _remoteAddress;
    
        public WSDiscoveryResponse(string content, HostName remoteAddress, string remotePort)
        {
            this._content = content;
            this._remoteAddress = remoteAddress;
            this._remotePort = remotePort;
        }
    }
    
    public class WSDiscoveryClient
    {
        private const string
            SRC_PORT = "0",//represents 'use any port available'
            DEST_IP_WSDISCOVERY = "239.255.255.250", //broadcast (ish)
            DEST_PORT_WSDISCOVERY = "3702";
    
        private TimeSpan _timeout = TimeSpan.FromSeconds(5);
    
        private List<WSDiscoveryResponse> _wsresponses = null;
    
        /// <summary>
        /// Get available Webservices
        /// </summary>
        public async Task<List<WSDiscoveryResponse>> GetAvailableWSEndpoints()
        {
            _wsresponses = new List<WSDiscoveryResponse>();
            using (var socket = new DatagramSocket())
            {
                try
                {
                    socket.MessageReceived += SocketOnMessageReceived;
                    //listen for responses to future message
                    await socket.BindServiceNameAsync(SRC_PORT);
                    //broadcast interrogation
                    await SendDiscoveryMessage(socket);
                    //wait for broadcast responses
                    await Task.Delay(_timeout).ConfigureAwait(false);
                }
                catch (Exception ex)
                {
                    SocketErrorStatus webErrorStatus = SocketError.GetStatus(ex.GetBaseException().HResult);
                }
            }
            return _wsresponses;
        }
    
        private string BuildDiscoveryMessage()
        {
            const string outgoingMessageFormat = @"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope"" xmlns:a=""http://www.w3.org/2005/08/addressing""><s:Header><a:Action s:mustUnderstand=""1"">http://docs.oasis-open.org/ws-dd/ns/discovery/2009/01/Probe</a:Action><a:MessageID>urn:uuid:{0}</a:MessageID><a:ReplyTo><a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address></a:ReplyTo><a:To s:mustUnderstand=""1"">urn:docs-oasis-open-org:ws-dd:ns:discovery:2009:01</a:To></s:Header><s:Body><Probe xmlns=""http://docs.oasis-open.org/ws-dd/ns/discovery/2009/01""><d:Types xmlns:d=""http://docs.oasis-open.org/ws-dd/ns/discovery/2009/01"" xmlns:dp0=""http://tempuri.org/"">dp0:IDiscoveryService</d:Types><Duration xmlns=""http://schemas.microsoft.com/ws/2008/06/discovery"">PT5S</Duration></Probe></s:Body></s:Envelope>";
            string outgoingMessage = string.Format(outgoingMessageFormat, Guid.NewGuid().ToString());
            return outgoingMessage;
        }
    
        private async Task SendDiscoveryMessage(DatagramSocket socket)
        {
            using (var stream = await socket.GetOutputStreamAsync(new HostName(DEST_IP_WSDISCOVERY), DEST_PORT_WSDISCOVERY))
            {
                string message = BuildDiscoveryMessage();
                var data = Encoding.UTF8.GetBytes(message);
                using (var writer = new DataWriter(stream))
                {
                    writer.WriteBytes(data);
                    await writer.StoreAsync();
                }
            }
        }
    
        private void SocketOnMessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
        {
            var dr = args.GetDataReader();
            string message = dr.ReadString(dr.UnconsumedBufferLength);
    
            _wsresponses.Add(new WSDiscoveryResponse(message, args.RemoteAddress, args.RemotePort));
        }
    }
