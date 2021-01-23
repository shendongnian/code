    public class MainViewModel:INotifyPropertyChanged
        {
            public MainViewModel()
            {
                Init();
            }
    
            public enum Calendar{
                ShowCalendarMaxLength = 145,
                HideCalenderHeight = 325,
                
            }
    
            private MeetingsListViewModel _listOfMeetingsViewModel;
            public MeetingsListViewModel ListOfMeetingsViewModel {
                get { return _listOfMeetingsViewModel; }
                set
                {
                    if (_listOfMeetingsViewModel != value)
                    {
                        _listOfMeetingsViewModel = value;
                        OnPropertyChanged("ListOfMeetings");
                    }
                }
    		 
            }
    
            public TaskListViewModel _listOfTasksViewModel;
            public TaskListViewModel ListOfTasksViewModel { 
                get{return _listOfTasksViewModel;}
                set {
                    if (_listOfTasksViewModel != value)
                    {
                        _listOfTasksViewModel = value;
                        OnPropertyChanged("ListOfTasks");
                    }
                }
            }
           
            private Calendar _calendarEventListBoxHeight;
            public Calendar CalendarEventListBoxHeight
             {
                 get { return _calendarEventListBoxHeight; }
                 set
                 {
                     if (_calendarEventListBoxHeight != value)
                     {
                         _calendarEventListBoxHeight = value;
                         OnPropertyChanged("CalendarEventListBoxHeight");
                     }
                 }
    
             }
    
            private bool _showCalendar;
            public bool ShowCalendar
            {
                get { return _showCalendar; }
                set {
                    if (_showCalendar != value)
                    {
                        _showCalendar = value;
                        OnPropertyChanged("ShowCalendar");
                    }
                }
            }
    
            private bool _showTasks;
            public bool ShowTasks
            {
                get { return _showTasks; }
                set
                {
                    if (_showTasks != value)
                    {
                        _showTasks = value;
                        OnPropertyChanged("ShowTasks");
                    }
                }
            }
    
            private bool _showMeetings;
            public bool ShowMeetings
            {
                get { return _showMeetings; }
                set
                {
                    if (_showMeetings != value)
                    {
                        _showMeetings = value; OnPropertyChanged("ShowMeetings");
                    }
                }
            }
      
            public void ShowCalendarAction()
            {
                ShowCalendar = true;
                CalendarEventListBoxHeight = Calendar.ShowCalendarMaxLength;
            }
    
            public void HideCalendarAction()
            {
                ShowCalendar = false;
                CalendarEventListBoxHeight = Calendar.HideCalenderHeight;
            }
    
            public void ShowMeetingsAction()
            {
                ShowTasks = false;
                ShowMeetings = true;
            }
    
            public void ShowTasksAction() {
                ShowMeetings = false;
                ShowTasks = true;
            }
    
            private void Init()
            {
                ShowCalendar = true;
                CalendarEventListBoxHeight = Calendar.ShowCalendarMaxLength;
                ShowMeetings = true;
                ShowTasks = false;
                ListOfMeetingsViewModel = new MeetingsListViewModel();
                ListOfTasksViewModel = new TaskListViewModel();
            }
    
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null) handler.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
