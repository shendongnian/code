    private void DoSmth()
    {
        if(ser.disconnect())
        {
            img_Ampel.Source = ampeln[0];
            bt_Connect.IsEnabled = true;
            bt_Disconnect.IsEnabled = false;
        }
    }
    
    private void bt_Disconnect_Click(object sender, RoutedEventArgs e)
    {
        DoSmth();
    }
    private void polling_tick(object sender, EventArgs e)
    {
        if (!serial_port.IsOpen)
        {
            mw.Show("...");
            polling.Stop();
            DoSmth();
        }
    }
