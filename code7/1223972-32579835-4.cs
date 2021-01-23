        private async void Play_Click(object sender, RoutedEventArgs e)
        {
            int x = await RandomNumber();
        }
        private async Task<int> RandomNumber()
            {
                int x = 0;
                int i = 0;
                string text = string.Empty;
                Random rng = new Random();
                // This will start work in background. Leaving GUI thread to it's own tasks.
                await Task.Factory.StartNew(() =>
                {
                    do
                    {
                        x = rng.Next(1, 1000000);
                        i++;
                        text = "\r\nAl zo vaak :O" + i.ToString(); //the rng loop
                        // This will invoke textbox update in GUI thread satisfying update requirement.
                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Input,
                            new Action(() => {  textBox.AppendText(text); }));
                         
                        // We will make it slower in order to see updates at adequate rate.
                        Thread.Sleep(100);
                    }
                    while (x != 1);    
                }); 
                // thanks to await we will have this code executed after we found our x==1.
                text = "\r\nHij heeft zo vaak geprobeerd 1 te halen " + i;
                textBox.AppendText(text);
                return x;
            } 
    
