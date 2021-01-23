    public class ExplorerControl : UserControl
    {
        public DelegateCommand RemoveCommand { get; set; }
        
        public ExplorerControl()
        {
            RemoveCommand = new DelegateCommand(Remove);
        }
        private void Remove()
        {
            // Do something here.
        }
    }
