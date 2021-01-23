		private async Task RefreshOrLoadDataToCache()
		{
			if (IsNeededToCallAPI())
			{
				DataTable dtTimeEntriesTemp = await LoadTimeEntriesTemp();
				DataTable dtEventsTemp = LoadEventsTemp();
		
				dtTimeEntriesTemp.Merge(dtEventsTemp);
			}
			else
				BindGridViews();
		}
