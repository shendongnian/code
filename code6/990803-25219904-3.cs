    Thread test = new Thread(() =>
    {
        String text, password, ipText, domainText;
        
        // !!!!!!This one should be simple Invoke because otherwise variables may not get their         
        // values before calls. Thanks @ScottChamberlain.!!!!!!
        datagrid_Disks.Dispatcher.Invoke(
          new Action(() =>
          {
              text = textbox_Username.Text;
              password = textbox_password.Password;
              ipText = textbox_IP.Text,
              domainText = textbox_Domain.Text
          }));
         var result = Server.GetDisksInfo(text, 
             password, 
             ipText,
             domainText);
         datagrid_Disks.Dispatcher.BeginInvoke(
          new Action(() =>
          {
            datagrid_Disks.ItemsSource = result;
          }));
     });
     test.Start();
