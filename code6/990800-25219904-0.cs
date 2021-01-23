    Thread test = new Thread(() =>
    {
         var result = Server.GetDisksInfo(textbox_Username.Text,
                                                               textbox_password.Password,
                                                               textbox_IP.Text,
                                                               textbox_Domain.Text);
         datagrid_Disks.Dispatcher.BeginInvoke(
          new Action(() =>
          {
            datagrid_Disks.ItemsSource = result;
          }));
     });
     test.Start();
