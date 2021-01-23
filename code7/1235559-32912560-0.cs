    private void Button_Click(object sender, RoutedEventArgs e)
    {
            Dispatcher.Invoke(DispatcherPriority.Render, new Action(() =>
            {
                var pWnd = new PopWindow();
                pWnd.ShowDialog();
                pWnd.InvalidateVisual();
                pWnd.UpdateLayout();
            }));
     }
