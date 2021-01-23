        public async Task ConnectToServiceAsync(string name)
        {
            lock(this.interlock)
            {
                readBuffer = String.Empty;
            }
            DeviceInformation serviceInfo = null;
            foreach (var device in devices)
            {
                if(device.Name == name)
                {
                    serviceInfo = device;
                    break;
                }
            }
            if (serviceInfo != null)
            {
                DeviceName = serviceInfo.Name;
                this.State = BluetoothConnectionState.Connecting;
                try
                {
                    // Initialize the target Bluetooth RFCOMM device service
                    connectService = RfcommDeviceService.FromIdAsync(serviceInfo.Id);
                    
                    rfcommService = await connectService;
                    if (rfcommService != null)
                    {
                        // Create a socket and connect to the target 
                        socket = new StreamSocket();
                        connectAction = socket.ConnectAsync(rfcommService.ConnectionHostName, rfcommService.ConnectionServiceName, SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
                        
                        await connectAction;//to make it cancellable
                        writer = new DataWriter(socket.OutputStream);
                        reader = new DataReader(socket.InputStream);
                        State = BluetoothConnectionState.Connected;
                        Task taskReceive = Task.Run(async () => { ListenForMessagesAsync(socket); });
                        taskReceive.ConfigureAwait(false);
                    }
                    else
                        OnExceptionOccuredEvent(this, new Exception("Unable to create service.\nMake sure that the 'bluetooth.rfcomm' capability is declared with a function of type 'name:serialPort' in Package.appxmanifest."));
                }
                catch (TaskCanceledException)
                {
                    this.State = BluetoothConnectionState.Disconnected;
                }
                catch (Exception ex)
                {
                    this.State = BluetoothConnectionState.Disconnected;
                    OnExceptionOccuredEvent(this, ex);
                } 
            }
        }
