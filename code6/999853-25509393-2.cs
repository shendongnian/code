    class MyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            var mylist = parameter as MyCommandArgs;
            if (mylist != null && mylist.CurrentItem is MyClassSelectAll)
            {
                foreach (var item in mylist.MyList)
                {
                    item.Selected = mylist.CurrentItem.Selected;
                }
            }
        }
    }
