	private void placeMarker(object sender, RoutedEventArgs e)
	{
		// txt_mark is your TextBox
		int index = txt_mark.CaretIndex;
		// I don't want the user to be able to place a marker at index = 0 or after the last character
		if (txt_mark.Text.Length > first && first > 0)
		{
			// Just calculations here
			Rect rect = txt_mark.GetRectFromCharacterIndex(first);
			Rect rect2 = txt_mark.GetRectFromCharacterIndex(first + 1);
			double X = (rect.Location.X + rect2.Location.X) / 2.0;
			Line line = new Line();
			line.X1 = X;
			line.X2 = X;
			line.Y1 = rect.Location.Y;
			line.Y2 = rect.BottomLeft.Y;
			line.HorizontalAlignment = HorizontalAlignment.Left;
			line.VerticalAlignment = VerticalAlignment.Top;
			line.StrokeThickness = 1;
			line.Stroke = Brushes.Red;
			
			// grid1 or any panel you have
			grid1.Children.Add(line);
		}
	}
