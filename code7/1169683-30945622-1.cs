    private void window1_KeyUp(object sender, KeyEventArgs e)
    {
    
      if(e.Key == Key.F)
      {
           if(!isFullScreen)
           {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                this.SC.VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                this.SC.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                isFullScreen = !isFullScreen;
           }
           else
           {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                this.SC.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
                this.SC.HorizontalScrollBarVisibility = ScrollBarVisibility.Visible;
                isFullScreen = !isFullScreen;
            }
       }
     }
