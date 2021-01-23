    private Student _SelectedStudentItem;
    public Student SelectedStudentItem
    {
        get
        {
            return _SelectedStudentItem;
        }
        set
        {
            // We need to remove this item from the previous student history
            if (_SelectedStudentItem != null)
                _SelectedStudentItem.History.Remove(Meeting.DateMeeting);
            _SelectedStudentItem = value;
            if (_SelectedStudentItem == null)
                return;
            _EditStudentButtonClickCommand.RaiseCanExecuteChanged();
            _DeleteStudentButtonClickCommand.RaiseCanExecuteChanged();
            OnPropertyChanged("SelectedStudentItem");
            if (ActiveStudentAssignmentType == StudentAssignmentType.BibleReadingMain)
                _Meeting.BibleReadingMainName = _SelectedStudentItem.Name;
            else if (ActiveStudentAssignmentType == StudentAssignmentType.BibleReadingClass1)
                _Meeting.BibleReadingClass1Name = _SelectedStudentItem.Name;
            else if (ActiveStudentAssignmentType == StudentAssignmentType.BibleReadingClass2)
                _Meeting.BibleReadingClass2Name = _SelectedStudentItem.Name;
        }
