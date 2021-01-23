	private void Button_Click(object sender, RoutedEventArgs e)
	{
		button.Visibility = Visibility.Hidden;
		Ellipse MainSnake = new Ellipse();
		MainSnake.Height = 10;
		MainSnake.Width = 10;
		MainSnake.Fill = Brushes.Yellow;
		Canvas.SetLeft(MainSnake, 250);
		Canvas.SetTop(MainSnake, 150);
		theCanvas.Children.Add(MainSnake);
	}
