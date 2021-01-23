	public string sunOpenTime
	{
		get
		{
			int hours = 0;
			int mins = 0;
			if (int.TryParse(ddlSundayOpenTimeHr.Text, hours) && int.TryParse(ddlSundayOpenTimeHr.Text, mins))
			{
			    TimeSpan ts;
			    if (ddlSundayFrom.SelectedValue == "PM")
			    {
			        ts = new TimeSpan(hours + 12, mins, 0);   
				}
				else
				{
			        ts = new TimeSpan(hours + 12, mins, 0);
				}
				return ts.ToString();//There are numerous ways to format the time string, check link below.
			}
			else
			{
				    return "Invalid Time";//Indicatory msg - Handle it the way you want.
			}
		}
		set
		{
			sunOpenTime = value;
		}
	}
