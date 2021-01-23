     var myViewModel = (MyViewModel)this.DataContext;
     Button sendButton = new Button
                         {
                              Name = "SendButton",
                              Command = myViewModel.SendCommand,
                              // etcd
                         }
