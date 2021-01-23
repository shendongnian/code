    Dispatcher.BeginInvoke(DispatcherPriority.Input,
                           new Action(delegate()
                           {
                               box.SelectedItem = item;
                           }));
