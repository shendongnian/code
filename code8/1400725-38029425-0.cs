    public OCLMEditorModelView()
    {
        InitTreasureItemMethodsList();
        InitReadingStudyPointsList();
        InitStudentStudyPointsList();
        _Model = new OCLMEditorModel();
        _DeleteStudentButtonClickCommand = new DelegateCommand<string>(
            (s) => { _Model.Students.Remove(_SelectedStudentItem); _Model.Serialize(); MessageBox.Show("Student deleted!"); }, //Execute
            (s) => { return _SelectedStudentItem != null; } //CanExecute
            );
    }
