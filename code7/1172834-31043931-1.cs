    public class ViewModel : INotifyPropertyChanged //this is important
    {
        
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private Model model;
        public List<CheckState> checkStates = new List<CheckState>();
        public List<CheckState> CheckStates
        {
            get { return checkStates; }
            set
            {
                checkStates = value;
                RaisePropertyChanged("CheckStates"); //And this is important
            }
        }
        public ViewModel()
        {
            InitializeModel();
        }
        private void InitializeModel()
        {
            //here to retrieve data from your database
            model = new Model
                        {
                            CheckStates = new[] { true, false, true, false }
                        };
            foreach(var stateItem in model.CheckStates)
            {
                this.checkStates.Add(new CheckState(stateItem));
            }
        }
    }
