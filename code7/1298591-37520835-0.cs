     Thread windowThread = new Thread(new ThreadStart(() =>
            {
                MyWindow NSWindow = new MyWindow();
                // When the window closes, shut down the dispatcher
                NSWindow.Closed += (s, e) =>
                Dispatcher.CurrentDispatcher.BeginInvokeShutdown(DispatcherPriority.Background);
                NSWindow.Show();
                // Start the Dispatcher Processing
                System.Windows.Threading.Dispatcher.Run();
            }));
            windowThread.SetApartmentState(ApartmentState.STA);
            // Make the thread a background thread
            windowThread.IsBackground = true;
            // Start the thread
            windowThread.Start();
