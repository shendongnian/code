    public TaskList SelectedTaskList
    {
                get { return selectedTaskList; }
                set
                {
                    selectedTaskList = value;
                    RaisePropertyChanged(nameof(SelectedTaskList));
                    DeleteTaskCommand.RaiseCanExecuteChanged();
                }
    }
            
    public BasicTask SelectedTask
    {
                get { return selectedTask; }
                set
                {
                    selectedTask = value;
                    RaisePropertyChanged(nameof(SelectedTask));
                    DeleteTaskCommand.RaiseCanExecuteChanged();
                }
    }
