    internal class MyModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                Set(() => Name, ref _name, value);
                RaisePropertyChanged(() => IsReady);
            }
        }
        public bool IsReady
        {
            get { return !string.IsNullOrEmpty(Name); }
        }
    }
