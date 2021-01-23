		private void CommonCode(object sender, object _e)
		{
			//Sender is common
			ListView parent = (ListView)sender;
			string strListViewButtonName = (sender as ListView).Name;
			
			if (_e is StylusButtonEventArgs)
			     ... (_e as StylusButtonEventArgs).GetPosition(parent));
			else
				 ... (_e as MouseEventArgs).GetPosition(parent));
		}
