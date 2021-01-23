    private void button_Click(object sender, RoutedEventArgs e)
    {
        Thread sta = new Thread(delegate ()
        {
            Window1 w = new Window1();
            w.Show();
            System.Windows.Threading.Dispatcher.Run();
        });
        sta.SetApartmentState(ApartmentState.STA);
        sta.Start();
    }
