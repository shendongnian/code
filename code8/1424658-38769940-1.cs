     private Binding GetBinding()
        {
            var config = new BindingElementCollection();            
            config.Add(new BinaryMessageEncodingBindingElement()
            {
                CompressionFormat = CompressionFormat.GZip,
            });
            config.Add(new HttpsTransportBindingElement()
            {
                MaxBufferPoolSize = 12000000,
                MaxBufferSize = 6000000,
                MaxReceivedMessageSize = 6000000,
                TransferMode = TransferMode.Streamed,
            });
            var resultBinding = new CustomBinding(config)
            {
                OpenTimeout = TimeSpan.FromMinutes(1),
                CloseTimeout = TimeSpan.FromMinutes(1),
                ReceiveTimeout = TimeSpan.FromMinutes(1),
                SendTimeout = TimeSpan.FromMinutes(1),
            };
            return resultBinding;
        }
