    private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        switch(e.PropertyName)
        {
            case "Status":
                UpdateStepStatusFromTasks();
                break;
            case "Time":
                UpdateStepTimesFromTasks();
                break;
         }
    }
