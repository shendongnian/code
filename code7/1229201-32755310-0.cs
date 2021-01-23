    public class MainViewModel : ViewModelBase
    {
        private readonly DateTime _somePreviousDate = DateTime.Today.AddDays(-2);
        private DateTime? _startDateSelected;
        public DateTime? StartDateSelected
        {
            get
            {
                return _startDateSelected.HasValue ? _startDateSelected : _somePreviousDate;
            }
            set
            {
                _startDateSelected = value.HasValue ? value : _somePreviousDate;
                OnPropertyChanged("StartDateSelected");
                OnPropertyChanged("StartDateSelectedString");
            }
        }
        public string StartDateSelectedString
        {
            get { return StartDateSelected.ToString(); }
        }
    }
            <DatePicker Height="25" HorizontalAlignment="Left" VerticalAlignment="Top" Width="115" 
                        SelectedDate="{Binding StartDateSelected, Mode=TwoWay}"
                        Text="{Binding StartDateSelectedString}">
            </DatePicker>
