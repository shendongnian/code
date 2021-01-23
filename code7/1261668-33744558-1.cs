    public new void Show()
    {
        var hasOtherWindow=false;
        //Ensure new notifications are placed above older ones
        foreach (Window window in System.Windows.Application.Current.Windows)
        {
            string windowName = window.GetType().Name;
            if (!windowName.Equals("NotificationAll") && window != this)
            {
                hasOtherWindow=true;
                window.Topmost = true;
                //Position the Notification
                var workingArea = SystemParameters.WorkArea;
                window.Left = (workingArea.Width - window.ActualWidth) / 2;
                window.Top = workingArea.Bottom - window.ActualHeight;
    			break;//GET OUT OF LOOP YOU WILL HAVE ONLY ONE WINDOW
            }
        }
        if(hasOtherWindow)
    	Close();//CLOSE THIS WINDOW
    }
