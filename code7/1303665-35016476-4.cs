     class ViewModel
        {
            public bool canExecute { get; set; }
            private RelayCommand saveStudentRecord; 
            private ObservableCollection<Model> dGrid;
            public ViewModel()
            {
                dGrid = new ObservableCollection<Model>();
            }
    
            private void MyAction()
            {
               dGrid.Add(new Model(){
                   TextName = valueOfTextTextBox,
                   RollNumber = valueOfRollNumberTextBox,
                   Class = valueOfClassTextBox
               });
            }     
        }
