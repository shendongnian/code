    private void OnFilter() {	
    	var filterViewModel = ViewModelLocator.FilterViewModel;
    
    	/* ... */
    
    	var filterWindow = new FilterWindow {
    		DataContext = filterViewModel,
    		Owner = GetParentWindow()
    	};
    	filterWindow.ShowDialog();
    	SelectedIndex = 0;
    }
    	  
    private static Window GetParentWindow() {
    	Window parent = null;
    
    	var activeWindows = Application.Current.Windows.Cast<Window>().Where(item => (item).IsActive).ToList();
    	if (activeWindows.Any()) {
    	parent = activeWindows[activeWindows.Count - 1];
    	}
    	else {
    		foreach (var item in 
    			Application.Current.Windows.Cast<object>().Where(item => item.GetType().Name == typeof(RibbonWindow).Name)) {
    			parent = item as Window;
    		}
    	}
    	return parent;
    }
