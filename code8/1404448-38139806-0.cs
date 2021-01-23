    private void RunPing2()
    {
      listView1.Clear();
      listView1.Columns.Add("Device IP", 100);
      listView1.Columns.Add("ping", 60);
    
      string[] addresses = {"192.168.1.6", "192.168.1.3", "192.168.1.4", "google.com"};
      var syncObj = new object();
      foreach (var address in addresses)
      {
        Task.Factory.StartNew(() =>
        {
          var ping = new Ping();
          try
          {
            var reply = ping.Send(address);
            lock (syncObj)
            {
              Invoke(new MethodInvoker(delegate
              {
                string[] A = {address, reply.RoundtripTime.ToString()};
                var item = new ListViewItem(A);
                listView1.Items.Add(item);
              }));
            }
          }
          catch (Exception)
          {
          }
        });
      }
    }
