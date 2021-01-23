    	private void listView_StylusButtonDown(object sender, StylusButtonEventArgs e) { CommonCode(sender, e.GetPosition((ListView)sender)); }
		private void listView_PreviewMouseLeftButtonDown(object sender, MouseEventArgs e) { CommonCode(sender, e.GetPosition((ListView)sender)); }
		private void CommonCode(object sender, Point p)
		{
			//Sender is common
			ListView parent = (ListView)sender;
			string strListViewButtonName = (sender as ListView).Name;
			
			//you don't need getPosition since P is known
		}
