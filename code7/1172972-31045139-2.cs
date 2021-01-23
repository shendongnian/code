       private void Button_Click(object sender, RoutedEventArgs e)
        {
            CallLongRunningMethod();
            Label3.Content = "Working...";        
        }
        private async void CallLongRunningMethod()
        {
            string result = await LongRunningMethodAsync("World");
            Label3.Content = result;
        }
        private string LongRunningMethodAsync(string message)
        {
            Thread.Sleep(2000);
            return "Hello " + message;
        }
       
