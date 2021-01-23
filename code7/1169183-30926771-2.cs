        bw.DoWork += (sender, args) =>
        {
        Dispatcher.BeginInvoke(DispatcherPriority.Loaded,new Action(()=>
                                {
                                    //code that changes progress-bar
                                }
                               ));
         }
