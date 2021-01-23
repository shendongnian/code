     private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            System.Windows.Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                progress.Value = e.ProgressPercentage;
            }), null);
        }
