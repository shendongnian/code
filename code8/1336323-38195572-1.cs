        public MainPage()
        {
            this.InitializeComponent();
            //txtblkMessages.Text = "test";
            Start();
        }
        private static int MESSAGE_COUNT = 1;
       
        private const string DeviceConnectionString = "HostName=[your hostname];DeviceId=[your DeviceId];SharedAccessKey=[your shared key]";
        public async Task Start()
        {
            try
            {
                DeviceClient deviceClient = DeviceClient.CreateFromConnectionString(DeviceConnectionString, TransportType.Amqp);
                //await SendEvent(deviceClient);
                await ReceiveCommands(deviceClient);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in sample: {0}", ex.Message);
            }
        }
        async Task SendEvent(DeviceClient deviceClient)
        {
            string dataBuffer;
            //for (int count = 0; count < MESSAGE_COUNT; count++)
            //{
            dataBuffer = "Hello Iot";
            Message eventMessage = new Message(Encoding.UTF8.GetBytes(dataBuffer));
            await deviceClient.SendEventAsync(eventMessage);
            // }
        }
        async Task ReceiveCommands(DeviceClient deviceClient)
        {
            Message receivedMessage;
            string messageData;
            while (true)
            {
                receivedMessage = await deviceClient.ReceiveAsync();
                if (receivedMessage != null)
                {
                    messageData = Encoding.ASCII.GetString(receivedMessage.GetBytes());
                    txtblkMessages.Text = messageData + "\n" + txtblkMessages.Text;
                    await deviceClient.CompleteAsync(receivedMessage);
                }
                //  Note: In this sample, the polling interval is set to 
                //  10 seconds to enable you to see messages as they are sent.
                //  To enable an IoT solution to scale, you should extend this //  interval. For example, to scale to 1 million devices, set 
                //  the polling interval to 25 minutes.
                //  For further information, see
                //  https://azure.microsoft.com/documentation/articles/iot-hub-devguide/#messaging
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
