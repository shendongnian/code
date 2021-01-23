    public class DeviceWrapper
    {
        // external device which provides real time stream of data
        private InternalDevice device = new InternalDevice();
        // internal buffer replaced by the bufferBlock
        BufferBlock<byte> bufferBlock = new BufferBlock<byte>()
        
        public void StartReceiving() {...}
        
        private async void DataAvailableHandler(object sender, DataEventArgs e)
        {
            // get the input and convert it to a byte
            // post the byte to the buffer block asynchronously
            byte byteToSend = ...
            await this.bufferBlock.SendAsync(byteToSend);
        }
        public async Task<IEnumerable<byte>> GetData(CancellationToken token)
        {
            List<byte> receivedBytes = new List<byte>()
            while (await this.BufferBlock.OutputAvailableAsync(token))
            {   // a byte is available
                byte b = await this.bufferBlock.ReceiveAsync(token);
                receivedBytes.Add(b);
                if (receivedBytes.Count > ...)
                {
                    return receivedBytes;
                }
                // else: not enough bytes received yet, wait for more
            }
        }
    }   
    
    async Task Test(CancellationToken token)
    {
        DeviceWrapper w = new DeviceWrapper();
        w.StartReceiving();
        while(NoStopRequested)
        {
            token.ThrowIfCancellationrequested();
            var filteredData = await w.GetData(token);
            Use(filteredData);
        }
    }
