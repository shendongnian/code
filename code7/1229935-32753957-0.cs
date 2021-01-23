            private void Button_Click(object sender, RoutedEventArgs e)
            {
                DisplayNextRandomImage();
    
                Dispatcher disp = ImageViewer.Dispatcher;
                DispatcherTimer t = new DispatcherTimer(TimeSpan.FromSeconds(10), DispatcherPriority.Normal, timer_Tick , disp);
                t.Start();
            }
    
            void timer_Tick(object sender, EventArgs e)
            {
                DisplayNextRandomImage();
            }
