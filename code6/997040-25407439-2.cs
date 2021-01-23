	private void placeMarker(object sender, RoutedEventArgs e)
	{
		// txt_mark is your TextBox
		int index = txt_mark.CaretIndex;
		// I don't want the user to be able to place a marker at index = 0 or after the last character
		if (txt_mark.Text.Length > first && first > 0)
		{
			Rect rect = txt_mark.GetRectFromCharacterIndex(first);
			Line line = new Line();
			// If by any chance, your textbox is in a scroll view,
			// use the scroll view's margin instead
			line.X1 = line.X2 = rect.Location.X + txt_mark.Margin.Left;
			line.Y1 = rect.Location.Y + txt_mark.Margin.Top;
			line.Y2 = rect.Bottom + txt_mark.Margin.Top;
			line.HorizontalAlignment = HorizontalAlignment.Left;
			line.VerticalAlignment = VerticalAlignment.Top;
			line.StrokeThickness = 1;
			line.Stroke = Brushes.Red;
			
			// grid1 or any panel you have
			grid1.Children.Add(line);
			// set the grid position of the line to txt_mark's one
			Grid.SetRow(line, 2);
			Grid.SetColumn(line, 2);
		}
	}
