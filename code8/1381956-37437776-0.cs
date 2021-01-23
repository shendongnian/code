	Dispatcher.BeginInvoke(new Action(() =>
    {
        viewerImage.Source = GetSnapAtMouseCoords(
		    (int)((Grid)viewerImage.Parent).ActualWidth, 
			(int)((Grid)viewerImage.Parent).ActualHeight, 
			System.Windows.Forms.Cursor.Position);
    }));
