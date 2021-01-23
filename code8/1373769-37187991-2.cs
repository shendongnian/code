    public class CloseConfirmViewModel
    {
        internal Window Owner { get; set; }
        public ICommand CloseCommand { get; private set; } // ICommand to bind it to a Button
        public CloseConfirmViewModel()
        {
            CloseCommand = new RelayCommand<object>(Close);
        }
        public void Close() // You can make it public in order to call it from codebehind
        {
            if (Owner == null)
                return;
            Owner.Close();
        }
    }
