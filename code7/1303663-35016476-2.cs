     class ViewModel
        {
            public bool canExecute { get; set; }
            private RelayCommand saveStudentRecord; 
            private ObservableCollection<Model> dGrid;
            public ViewModel()
            {
                dGrid = new ObservableCollection<Model>();
            }
            public Model EditedModel {
                get {
                    return _editedModel;
                }
                set {
                    _editedModel = value;
                    SignalPropertyChanged("EditedModel");
                }
            }
    
            private void MyAction()
            {
               dGrid.Add(EditedModel);
               EditedModel = new Model();
            }
            void SignalPropertyChanged(string propertyName){
                if(propertyChanged !=null){
                    propertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
     
        }
