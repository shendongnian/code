    private Nullable<DateTime> selectedDate;
    public Nullable<DateTime> SelectedDate
    {
        get { return selectedDate; }
        set 
        {
            if (selectedDate != value) { /* SelectedDate has changed */ }
            selectedDate = value; 
            NotifyPropertyChanged("SelectedDate");
        }
    }
...
    <Calendar SelectedDate="{Binding SelectedDate}" />
