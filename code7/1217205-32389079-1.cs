    this.Dispatcher.Invoke((Action)(() => {
    	progress1.IsActive = true;
    	progress1.Visibility = Visibility.Visible;
    	DataTable dtSong = new DataTable();
    	//All Steps will go as stated
    	view.GroupDescriptions.Add(new PropertyGroupDescription("Artist"));
    	progress1.IsActive = false;
    	progress1.Visibility = Visibility.Collapsed;
    }));
