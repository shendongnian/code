    public class ViewModel
    {
        public ICommand checkedCommand { get; set; }
        public ViewModel()
        {
            checkedCommand = new CheckedCommand(this);
        }
        public void CheckedHandler()
        {
            //todo - implement your handler
        }
    }
