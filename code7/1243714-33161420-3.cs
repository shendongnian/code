	protected void DateChanged(object sender, EventArgs e)
	{
		calendarsubjects.InnerHtml = calendar.SelectedDate.ToString("ddd");
	}
	
