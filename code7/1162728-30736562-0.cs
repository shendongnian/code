    protected override async void OnKeyDown(KeyRoutedEventArgs e)
    {
    	if (e.Key == Windows.System.VirtualKey.Enter && (xaml_search_box.FocusState == Windows.UI.Xaml.FocusState.Pointer || xaml_search_box.FocusState == Windows.UI.Xaml.FocusState.Keyboard))
    	{
    		//We want to make the progressbar visible here
    		xaml_search_progressbar.Visibility = Windows.UI.Xaml.Visibility.Visible         
    
    		//collapse keyboard
    		Windows.UI.ViewManagement.InputPane.GetForCurrentView().TryHide(); 
            // Yield control to the UI thread
            await Task.Delay(10);
    
    		string _query = xaml_search_box.Text;
    		List<Task> tasks = new List<Task>();
    
    		//Long web request
    		Task t = Task.Run(() => APICall.BasicSearch(_query));
    		tasks.Add(t);             
    		Task.WaitAll(tasks.ToArray());
    
    		m_results = APICall.m_basicsearch;
    		xaml_search_results.ItemsSource = m_results;
    		xaml_search_results_grid.ItemsSource = m_results;                
    	}
    
    	base.OnKeyDown(e);
    	//Our layout is updated here, AFTER we have done the search making it pointless to show a loading bar
    }
