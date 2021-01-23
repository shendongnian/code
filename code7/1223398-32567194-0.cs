        private async void button_Click(object sender, RoutedEventArgs e)
        {
            var messageBus = new MessageBus();
            messageBus.GetMessages<Message>().ObserveOnDispatcher().Subscribe(x => TestHanlder(x));
            Trace.WriteLine("Main Thread Id:" + Thread.CurrentThread.ManagedThreadId);
            var deviceManager = new DeviceManager(messageBus);
            await deviceManager.Start();
        }
        ...
            public async Task<Unit> Start()
            {
                for (;;)
                {
                    await Task.Factory.StartNew(() => BackGroundTask(), TaskCreationOptions.LongRunning);
                }
            }
