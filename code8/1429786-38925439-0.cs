        private void clockTimer_Tick(object sender, ElapsedEventArgs e)
        {
            timer.Stop();
            Action a = () =>
            {
                worker.RunWorkerAsync();
            };
            Application.Current.Dispatcher.BeginInvoke(a);
        }
