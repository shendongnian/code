    public class ViewModel
    {
        public ICommand MyCommand { get; set; }
        public ViewModel()
        {
            MyCommand = new DelegateCommand(OnRectangleClicked);
        }
        public void OnRectangleClicked()
        {
            // Change boolean here
        }
    }
