    private async void Window_StateChanged_1(object sender, EventArgs e)
        {
            await MaximizeWindow(this);
        }
        public Task MaximizeWindow(Window window)
        {
            return Task.Factory.StartNew(() =>
            {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    Thread.Sleep(100);
                    window.WindowState = System.Windows.WindowState.Maximized;
                }));
            });
        }
