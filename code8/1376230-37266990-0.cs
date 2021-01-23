    public ObservableCollection <AttendeeSearchDTO> SelectedAttendees
    {
        get
        {
            return selectedAttendees;
        }
        set
        {            
            if (selectedAttendees != value)
            {
                selectedAttendees = value;
                this.OnPropertyChanged(() => this.SelectedAttendees);
            }
        }
    }
