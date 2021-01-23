        private RelayCommand myCommandInViewModel;
        public RelayCommand MyCommandInViewModel
        {
            get { return myCommandInViewModel?? (myCommandInViewModel= new RelayCommand(myCommandInViewModelAction,()=> { return isFolder; })); }
        }
