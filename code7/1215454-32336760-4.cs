     public Task SelectedTask
        {
            get { return selectedTask; }
            set
            {
                selectedTask = value;
                OnPropertyChanged("SelectedTask");
                OnPropertyChanged("ButtonText");
            }
        }
    public string ButtonText
    {
      get { return this.SelectedTask.EndDate == null ? "Close Task" : "Resume Task"; }
    }
    
