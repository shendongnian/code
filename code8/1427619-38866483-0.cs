    public override async void OnShow()
    {
    	var calendarList = await DataService.GetListAsync();
    
    	CalendarList = new ObservableCollection<Model>(calendarList.OrderBy(a => a.Date));
    }
