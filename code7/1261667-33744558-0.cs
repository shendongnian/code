    public new void Show()
    {
    	//Ensure new notifications are placed above older ones
        foreach (Window window in System.Windows.Application.Current.Windows)
        {
            string windowName = window.GetType().Name;
            //ALSO CHECK BY PLACING BREAKPOINT AT THIS if TO SEE WHAT WINDOW
            //NAME ARE YOU GETTING OR IF YOU ARE ENTRING THIS BLOCK
            if (windowName.Equals("NotificationAll") && window != this)
            {
               //IF YOU WANT TO CLOSE PREVIOUS WINDOWS
               window.Close();
            }
         }
         
          //NOW MANIPLUATE CURRENT WINDOW'S PROPERTIES AND SHOW IT
          this.Topmost = true;
          base.Show();
           ....
           ....
           this.Top = workingArea.Bottom - this.ActualHeight;
    }
