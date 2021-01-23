    private void Scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
    {
       ScrollViewer scroll = (ScrollViewer)sender;
       if(scroll.HorizontalScrollBarVisibility == ScrollBarVisibility.Auto)
       {
          if (scroll.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
          {
             scroll.HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
             BPanel.Visibility = Visibility.Visible;
          }
       }
    }
