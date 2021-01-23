    using GalaSoft.MvvmLight.Messaging;
    ...
    private void btn_send_Click(object sender, RoutedEventArgs e)
    {
        var msg = new MyMessage2() { Text = txt_input.Text };
        Messenger.Default.Send<MyMessage2>(msg);
    }
  
