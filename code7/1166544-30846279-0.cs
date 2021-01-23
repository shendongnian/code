    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Thread thread = new Thread(() =>
        {
            Window1 window = new Window1();
            window.Closed += (s, a) => window.Dispatcher.InvokeShutdown();
            window.Show();
            System.Windows.Threading.Dispatcher.Run();
        });
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
    }
