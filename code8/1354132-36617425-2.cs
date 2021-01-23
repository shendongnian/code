    public class ViewModelCommands : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            //if it's a tapped event
            if (parameter is TappedRoutedEventArgs)
            {
                var tappedEvent = (TappedRoutedEventArgs)parameter;
                var gridSource = (Grid)tappedEvent.OriginalSource;
                var dataContext = (MainPageModel)gridSource.DataContext;
                //if tick is true then set to false, or the opposite.
                if (dataContext.isFav == null)
                {
                    dataContext.isFav = true;
                } else
                {
                    dataContext.isFav = !dataContext.isFav;
                }
            }
        }
    }
