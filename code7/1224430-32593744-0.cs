    private object syncGate = new object();
    private Thread browserWindowThread;
    private Window browserWindow;
    
    private void btn_LaunchWPFBrowser_Click(object sender, RoutedEventArgs e)
    {
    	try
    	{
    		lock (syncGate)
    		{
    			if (browserWindowThread == null)
    			{
    				browserWindowThread = new Thread(() =>
    				{
    					var wpfwindow = new WPF_Windows.wpf_Browser();
    					wpfwindow.Show();
    					wpfwindow.Closed += (sender2, e2) => wpfwindow.Dispatcher.InvokeShutdown();
    					lock (syncGate)
    						browserWindow = wpfwindow;
    					// Start the Dispatcher Processing
    					System.Windows.Threading.Dispatcher.Run();
    					lock (syncGate)
    					{
    						browserWindow = null;
    						browserWindowThread = null;
    					}
    				});
    				browserWindowThread.IsBackground = true;
    				// Set the apartment state
    				browserWindowThread.SetApartmentState(ApartmentState.STA);  //setting new thread’s apartment state to STA, this is a WPF requirement
    				browserWindowThread.Start();
    			}
    			else if (browserWindow != null)
    			{
					browserWindow.Dispatcher.BeginInvoke(new Func<bool>(browserWindow.Activate));
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		string additionalMessage = "In method '" + TraceCallerClass.TraceCaller() + "' ";
    
    		MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    	}
    }
    
    protected override void OnClosed(EventArgs e)
    {
    	base.OnClosed(e);
    	lock (syncGate)
    	{
    		if (browserWindow != null)
    			browserWindow.Dispatcher.BeginInvoke(new Action(browserWindow.Close));
    	}
    }
