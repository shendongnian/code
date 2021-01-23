    SelectedDatesCollection selectedDatesCollection = myCalendar.SelectedDates;
    
    if (selectedDatesCollection.Count > 0)
    {
    	if (selectedDatesCollection.Any(x => x < new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)))
    		MessageBox.Show("passed or less than today");
    	else
    		MessageBox.Show("today or future date");
    }
