     public ObservableCollection<DayModel> Day
        {
            get;
            set;
        }
        public ViewModel()
        {
            Day = new ObservableCollection<DayModel>();
            for(int i = 0; i < 31; i++)
            {
                Day.Add(new DayModel
                {
                    date=i+1
                });
            }
        }
  
