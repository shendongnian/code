    public static void CloseWindow_CanExecute(object sender,
                           CanExecuteRoutedEventArgs e)
        {
            // Find the resource, then cast it to a runtimeObject
            var runtime = (runtimeObject)Application.Current.TryFindResource("runtimeVariables");
            if (runtime.InProgress == true)
            {
                e.CanExecute = false;
            }
            else
            {
                e.CanExecute = true;
            }
        }
