    public class MainViewModel
    {
        public MainViewModel()
        {
        }
        private ICommand clickMeCommand;
        public ICommand ClickMeCommand
        {
            get
            {
                if (clickMeCommand == null)
                    clickMeCommand = new RelayCommand(i => this.ClickMe(), null);
                return clickMeCommand;
            }
        }
        private void ClickMe()
        {
            MessageBox.Show("You Clicked Me");
        }
    }    
