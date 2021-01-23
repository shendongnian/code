    class SelectedValueUpdated : ICommand
    {
        private MenuTreeViewModel _mvModel;
        public event EventHandler CanExecuteChanged
        {
            add { }
            remove { }
        }
        public SelectedValueUpdated(MenuTreeViewModel mvModel)
        {
            _mvModel = mvModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            RoutedPropertyChangedEventArgs<object> e = (RoutedPropertyChangedEventArgs<object>)parameter;
            if (e.NewValue is Models.MenuTree)
            {
                // This is the Top Level Clients item
                // Nothing needs to be done.
                // clear out Current items of all Model types
                //   MenuTree tree = (MenuTree)e.NewValue;
            }
            if (e.NewValue is Models.Provider)
            {
                //MessageBox.Show("Provider";
                // Set CurrentProvider to the selected item.
                Dal db = new Dal();
            }
            if (e.NewValue is Models.Batch)
            {
                MessageBox.Show("Batch");
            }
            if (e.NewValue is Models.Consumer)
            {
                MessageBox.Show("Consumer");
            }
        }
    }
