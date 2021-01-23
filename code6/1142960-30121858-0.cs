    <DatePicker x:Name="datePicker1" Grid.Row="6" Grid.Column="2" SelectedDate="{Binding DueDate, Mode=TwoWay}" IsEnabled="{Binding IsDatePickerEnabled}"/>    
    private bool _isDatePickerEnabled;
    public bool IsDatePickerEnabled
    {
        get{return _isDatePickerEnabled;}
        set 
        {
            _isDatePickerEnabled = value;
            OnPropertyChanged(()=>IsDatePickerEnabled);
        }
    }
