    public class DeleteCommand: ICommand
    {
        private ParentVM Parent { get; set; }
        private MyTabItemViewModel Item { get; set; }
    
        public MyCustomCommand (ParentVM parent, MyTabItemViewModel item)
        {
            Parent= parent;
            Item = item;
        }
    
        public bool CanExecute(object parameter)
        {
            return true;
        }
    
        public void Execute(object parameter)
        {
            parent.RemoveItem(item);
        }
        ...
    }
