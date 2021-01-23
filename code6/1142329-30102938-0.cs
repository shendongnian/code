    private void button_Click(object sender, RoutedEventArgs e)
        {          
            Task.Run(() => {
                Thread.Sleep(3000);
                //LongTimeStuff
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    textBlock1.Text = "10";
                    
                }));
            });
        }
