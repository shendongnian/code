        private IFirstReadViewModelDAL dbFunctions;
        private string _scriptNotes;
        public string ScriptNotes    //binded in the View
        {
            get { return _scriptNotes; }
            set { _scriptNotes = value; RaisePropertyChanged("ScriptNotes"); }
        }
        public FirstReadViewModel(IFirstReadViewModelDAL injectDAL)
        {
            dbFunctions = injectDAL;
        }
        private void LoadData();
        {
            // use your dbFunctions
        }
