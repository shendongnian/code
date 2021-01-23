    private void ActivityCalender_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
    {
    
    	for (int i = 0; i < GetActivityResponseObject.Workouts.Count; i++)
    	{
    		string[] DateArray = GetActivityResponseObject.Workouts[i].ActivityDate.Split('-');
    
    		ActivityCalender.SelectedDates.Add(new DateTime(int.Parse(DateArray[2]), int.Parse(DateArray[1]), int.Parse(DateArray[0])));
    	}
    }
