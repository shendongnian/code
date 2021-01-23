        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Action a = () => { Dispatcher.Invoke(() => { throw new Exception(); }); };
            a.BeginInvoke(Callback, a);
        }
        private void Callback(IAsyncResult ar)
        {
            ((Action)ar.AsyncState).EndInvoke(ar);
        }
