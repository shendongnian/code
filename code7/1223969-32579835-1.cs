       private int RandomNumber()
            {
                int x = 0;
                int i = 0;
                Random rng = new Random();
                // This will start work in background. Leaving GUI thread to it's own tasks.
                Task.Factory.StartNew(() =>
                {
                    do
                    {
                        x = rng.Next(1, 1000000);
                        i++;
                        TextboxData += "\r\nAl zo vaak :O" + i; //the rng loop
                        // This will invoke textbox update in GUI thread satisfying update requirement.
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                            new Action(() => {  textBox.Text = TextboxData; }));
                         
                        // We will make it slower in order to see updates at adequate rate.
                        Thread.Sleep(100);
                    }
                    while (x != 1);    
                }); 
                TextboxData += "\r\nHij heeft zo vaak geprobeerd 1 te halen " + i;
                textBox.Text = TextboxData + Environment.NewLine;
                return x;
            } 
    
