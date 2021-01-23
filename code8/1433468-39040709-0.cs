        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var a = Test();
            var b = Test();
            var c = Test();
            var d = Test();
            c.Wait();
        }
        public async Task Test()
        {
            await Task.Delay(1000);
        }
