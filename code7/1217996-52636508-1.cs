    public class AwesomeViewModel
    {
        public ICommand GoToTabCommand { get; set; }
        private AwesomeViewModel()
        {
            InitCommands();
        }
        private void InitCommands()
        {
            GoToTabCommand = new Command(GoToTab);
        }
        private void GoToTab()
        {
           MessagingCenter.Send<AwesomeViewModel, int>(this, "SetActiveTab", 1); //REPLACE 1 with the index of your tab
        }
    }
