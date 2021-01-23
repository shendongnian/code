    private void OnScrollChanged(object sender, ScrollChangedEventArgs e)
     {
         var scrollViewer = (ScrollViewer)sender;
         if (scrollViewer.VerticalOffset == scrollViewer.ScrollableHeight)
          {
             for (int i = 0; i < 5; i++)
              {
                 CboxItems.Add((CboxItems.Count+i).ToString());
              }
           }
      }
