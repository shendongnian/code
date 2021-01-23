	protected void DateChanged(object sender, EventArgs e)
	{
		calendarsubjects.InnerHtml = calendar.SelectedDate.Day.ToString("ddd");
	}
	
