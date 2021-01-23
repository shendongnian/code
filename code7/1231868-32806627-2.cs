              var pipename = System.IO.Directory.GetFiles(@"\\.\pipe\").FirstOrDefault(x => x.Contains("myApp")))
    
              IpcClientChannel clientChannel = new IpcClientChannel();
              ChannelServices.RegisterChannel(clientChannel, true);
              var s = (ServiceType)Activator.GetObject(typeof (ServiceType), "ipc://" + pipename.Replace(@"\\.\pipe\", string.Empty) + "/service");
              s.DoSomething("data");
              ChannelServices.UnregisterChannel(clientChannel);
