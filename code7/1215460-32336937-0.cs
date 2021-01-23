    Action action = new Action(() => { 
                    listBox1.Items.Add(sClientHost); 
                });
    this.Dispatcher.Invoke(action, DispatcherPriority.ApplicationIdle);
    
