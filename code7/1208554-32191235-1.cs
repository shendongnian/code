    public static readonly DependencyProperty SendToViewModelProperty =
            DependencyProperty.Register("SendToViewModel", typeof(ICommand), typeof(control), new PropertyMetadata(null));
        private void HandleEnter(object sender, MouseEventArgs e)
        {
            if (SendToViewModel != null)
            {
                var fe = sender as FrameworkElement;
                if (fe != null)
                {
                    if (SendToViewModel.CanExecute(fe.DataContext))
                    {
                        SendToViewModel.Execute(fe.DataContext);
                    }
                }
            }
        }
