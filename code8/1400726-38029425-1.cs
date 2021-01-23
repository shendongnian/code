    public OCLMEditorModelView()
    {
        InitTreasureItemMethodsList();
        InitReadingStudyPointsList();
        InitStudentStudyPointsList();
        _Model = new OCLMEditorModel();
        _DeleteStudentButtonClickCommand = new DelegateCommand<string>(
            ExecuteMethod, //Execute
            CanExecuteMethod//CanExecute
            );
    }
    void ExecuteMethod(string s)
    {
        _Model.Students.Remove(_SelectedStudentItem); 
        _Model.Serialize(); 
        MessageBox.Show("Student deleted!"); 
    }
    
    bool CanExecuteMethod(string s)
    {
        return _SelectedStudentItem != null;
    }
