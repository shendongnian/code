	void Item_Loaded(object sender, RoutedEventArgs e) {
        // Find the main grid of this TreeView item.
		Grid grid = FindVisualChild<Grid>((DependencyObject) sender);
        // Add new row, because it has only 2 and we need 3
		grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        // Get the content to put into the textblock (or another control you are using in datatemplate)
		string text = ((Node) grid.DataContext).Name;
        // I'm using TextBlock to show example, you can use your own control
		TextBlock tb = new TextBlock {
			Text = text,
			Foreground = new SolidColorBrush(Colors.Gray),
		};
		grid.Children.Add(tb);
        // Visibility of our modification depends on IsExpanded and amount of child elements. If itemcontainer is collapsed or doesn't have children, we don't show this modification.
		bool flag = false;
		grid.SizeChanged += (sender1, e1) => {
			if (flag) {
				return;
			}
			flag = true;
			tb.Visibility = grid.RowDefinitions[1].ActualHeight > 0
			? Visibility.Visible
			: Visibility.Collapsed;
			flag = false;
		};
        // Set the position of the added part
		tb.SetValue(Grid.RowProperty, 2);
		tb.SetValue(Grid.ColumnProperty, 1);
	}
