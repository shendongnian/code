    rfcommServiceInfoCollection = await DeviceInformation.FindAllAsync(
                    RfcommDeviceService.GetDeviceSelector(RfcommServiceId.ObexObjectPush));
    
                var count = rfcommServiceInfoCollection.Count;
    
                Debug.WriteLine("Count of RFCOMM Service: " + count);
    
                if(count > 0)
                {
                    lock (this)
                    {
                        streamSocket = new StreamSocket();
                    }
    
                    var defaultSvcInfo = rfcommServiceInfoCollection.FirstOrDefault();
    
                    rfcommDeviceService = await RfcommDeviceService.FromIdAsync(defaultSvcInfo.Id);
    
                    if(rfcommDeviceService == null)
                    {
                        Debug.WriteLine("Rfcomm Device Service is NULL, ID = {0}", defaultSvcInfo.Id);
    
                        return;
                    }
    
                    Debug.WriteLine("ConnectionHostName: {0}, ConnectionServiceName: {1}", rfcommDeviceService.ConnectionHostName, rfcommDeviceService.ConnectionServiceName);
    
                    await streamSocket.ConnectAsync(rfcommDeviceService.ConnectionHostName, rfcommDeviceService.ConnectionServiceName);
