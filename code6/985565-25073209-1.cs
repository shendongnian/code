    private void DoSomethingAsync() {
        MessageService messageService = new MessageService();
          
        ProgressBarVisibility = Visibility.Visible;
        Task.Factory.StartNew(() => { PerformCDDetection(messageService); }).ContinueWith(t => { ProgressBarVisibility = Visibility.Collapsed; });
    }
