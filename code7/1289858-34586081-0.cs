    public void buttonAnswer_Click(object sender, RoutedEventArgs e)
            {
                var syncContext = TaskScheduler.FromCurrentSynchronizationContext();
                Task t = new Task(() =>
                {
                    System.Threading.Thread.Sleep(1000);
                    MessageBox.Show("Test..");
                });
    
                t.Start(syncContext);
            }
