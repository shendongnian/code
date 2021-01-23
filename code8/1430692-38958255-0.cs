    private void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
    {
	    if (this.DataContext is ViewModel)
	    {
		    this.ViewModel = this.DataContext as ViewModel;
	    }
	    else
	    {
		    this.DataContext = this.ViewModel;
	    }
    }
