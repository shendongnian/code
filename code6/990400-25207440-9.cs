    private void zoomAndPanControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
	   if ((Keyboard.Modifiers & ModifierKeys.Shift) == 0)
	   {
		  Point doubleClickPoint = e.GetPosition(content);
		  
		  var viewModel = (MyViewModel)this.DataContext;
		  
		  viewModel.ExecuteAnimatedSnapTo(zoomAndPanControl.AnimatedSnapTo, doubleClickPoint);
	   }
	}	
