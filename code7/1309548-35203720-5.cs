    public class YourViewModel
    {
        public RelayCommand YourCommand { get; set; }
        public YourViewModel()
        {
            YourCommand = new RelayCommand(DoSmth, CanDoSmth);
        }
    
        private void DoSmth(object obj)
        {
            Message.Box("Hello from viewModel"); 
        }
    
        private bool CanDoSmth(object obj)
        {
           //you could implement your logic here. But by default it should be  
           //set to true
           return true;
        }
    }
