     public MainFormViewModel()
        {
            SelectedDropDown = "cbi1";
        }
     private string _SelectedDropDown;
        public string SelectedDropDown
        {
            get { return _SelectedDropDown; }
            set { _SelectedDropDown = value; NotifyPropertyChanged("SelectedDropDown"); }
        }
