    	MediaCapture mediaCapture;
        string serviceNameForConnect = "22112";
        string hostNameForConnect = "localhost";
        NetworkAdapter adapter = null;
        StreamSocket clientSocket = null;
		
		private async void StartListener_Click(object sender, RoutedEventArgs e)
        {
            StreamSocketListener listener = new StreamSocketListener();
            listener.ConnectionReceived += OnConnection;
            await listener.BindServiceNameAsync(serviceNameForConnect);
        }
        private async void ConnectSocket_Click(object sender, RoutedEventArgs e)
        {
            HostName hostName;
            mediaCapture = new MediaCapture();
            await mediaCapture.InitializeAsync();
            try
            {
                hostName = new HostName(hostNameForConnect);
            }
            catch (ArgumentException ex)
            {
                return;
            }
            clientSocket = new StreamSocket();
                        
            try
            {
                await clientSocket.ConnectAsync(hostName, serviceNameForConnect);
            }
            catch (Exception exception)
            {
                // If this is an unknown status it means that the error is fatal and retry will likely fail.
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                    throw;
                }
            }
        }
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            object outValue;
            // Create a DataWriter if we did not create one yet. Otherwise use one that is already cached.
            DataWriter writer;
            if (!CoreApplication.Properties.TryGetValue("clientDataWriter", out outValue))
            {
                writer = new DataWriter(clientSocket.OutputStream);
                CoreApplication.Properties.Add("clientDataWriter", writer);
            }
            else
            {
                writer = (DataWriter)outValue;
            }
            while (true)
            {
                var memoryStream = new InMemoryRandomAccessStream();
                await mediaCapture.CapturePhotoToStreamAsync(ImageEncodingProperties.CreateJpeg(), memoryStream);
                await Task.Delay(TimeSpan.FromMilliseconds(18.288)); //60 fps
                memoryStream.Seek(0);
                writer.WriteUInt32((uint)memoryStream.Size);
                writer.WriteBuffer(await memoryStream.ReadAsync(new byte[memoryStream.Size].AsBuffer(), (uint)memoryStream.Size, InputStreamOptions.None));
                // Write the locally buffered data to the network.
                try
                {
                    await writer.StoreAsync();
                }
                catch (Exception exception)
                {
                    // If this is an unknown status it means that the error if fatal and retry will likely fail.
                    if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                    {
                        throw;
                    }
                }
            }
        }
        private async void OnConnection(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            await Task.WhenAll(DownloadVideos(args));
        }
        public async Task DownloadVideos(StreamSocketListenerConnectionReceivedEventArgs args)
        {
            DataReader reader = new DataReader(args.Socket.InputStream);
            try
            {
                while (true)
                {
                    // Read first 4 bytes (length of the subsequent string).
                    uint sizeFieldCount = await reader.LoadAsync(sizeof(uint));
                    if (sizeFieldCount != sizeof(uint))
                    {
                        // The underlying socket was closed before we were able to read the whole data.
                        return;
                    }                    
                    uint stringLength = reader.ReadUInt32();
                    uint actualStringLength = await reader.LoadAsync(stringLength);
                    if (stringLength != actualStringLength)
                    {
                        // The underlying socket was closed before we were able to read the whole data.
                        return;
                    }
                    NotifyUserFromAsyncThread(reader.ReadBuffer(actualStringLength));
                }
            }
            catch (Exception exception)
            {
                // If this is an unknown status it means that the error is fatal and retry will likely fail.
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                    throw;
                }
            }
        }
        private void NotifyUserFromAsyncThread(IBuffer buffer)
        {
            var ignore = Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () =>
                {
                    Stream stream = buffer.AsStream();
                    byte[] imageBytes = new byte[stream.Length];
                    stream.ReadAsync(imageBytes, 0, imageBytes.Length);
                    InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream();
                    ms.AsStreamForWrite().Write(imageBytes, 0, imageBytes.Length);
                    ms.Seek(0);
                    var image = new BitmapImage();
                    image.SetSource(ms);
                    ImageSource src = image;
                    imageElement.Source = src;
                });
        }
