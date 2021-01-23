    public ICommand DeleteItem
        {
            get { return (ICommand)GetValue(DeleteItemProperty); }
            set { SetValue(DeleteItemProperty, value); }
        }
    public static readonly DependencyProperty DeleteItemProperty = DependencyProperty.Register("DeleteItem", typeof(ICommand), typeof(control), new PropertyMetadata(null));
    private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DeleteItem != null)
            {
                var result = System.Windows.MessageBox.Show("WOULD YOU LIKE TO DELETE?", "Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    var fe = sender as FrameworkElement;
                    if (DeleteItem.CanExecute(fe.DataContext))
                    {
                        DeleteItem.Execute(fe.DataContext);
                    }
                }
            }
