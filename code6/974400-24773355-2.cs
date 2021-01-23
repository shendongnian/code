    public CustomTable()
    {
        ...
        Errors = new ObservableCollection<DataColumnChangeEventArgs>();
    }
    private void tableColumnChanging(object sender, DataColumnChangeEventArgs e)
    {
        if (!isValid(e))
        {
            object badValue = e.ProposedValue;
            e.ProposedValue = "Bad Data";
            e.Row.RowError = "The column contains an error";
            e.Row.SetColumnError(e.Column, "Column cannot be " + badValue);
            Errors.Add(e);
            OnPropertyChanged("Errors");
        }
        else
        {
            DataColumnChangeEventArgs args = Errors.FirstOrDefault(ee => (ee.Row == e.Row) && (ee.Column == e.Column));
            if (args != null)
            {
                Errors.Remove(args);
                OnPropertyChanged("Errors");
            }
            //... 
        }
    }
    public ObservableCollection<DataColumnChangeEventArgs> Errors { get; set; }
