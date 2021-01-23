    public static void CloseWindow_CanExecute(object sender,
                           CanExecuteRoutedEventArgs e)
        {
            if (App.runtime.inProgress == true)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }
