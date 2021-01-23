        private void UpdateButtonContent(string text)
        {
            button.Content = text;
        }
        private void SimLongRunningProcess()
        {
            Thread.Sleep(2000);
        }
        private void OnProcessFinished(Task task)
        {
            string content;
            if(task.Exception != null)
            {
                content = task.Exception.Message;
            }
            else
            {
                content = "Success";
            }
            Dispatcher.BeginInvoke(new Action<string>(UpdateButtonContent), DispatcherPriority.Normal, content);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Start long running process and return immediatly
            var task = Task.Factory.StartNew(SimLongRunningProcess);
            task.ContinueWith(OnProcessFinished);
        }
