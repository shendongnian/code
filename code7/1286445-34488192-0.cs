        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Simply creating another UI thread on button click https://eprystupa.wordpress.com/2008/07/28/running-wpf-application-with-multiple-ui-threads/
            Thread thread = new Thread(() =>
            {
                SynchronizationContext.SetSynchronizationContext(
                new DispatcherSynchronizationContext(
                Dispatcher.CurrentDispatcher));
                MainWindow w = new MainWindow();
                //Crash!!
                w.Show();
                w.Closed += (sender2, e2) =>
                w.Dispatcher.InvokeShutdown();
                System.Windows.Threading.Dispatcher.Run();
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
