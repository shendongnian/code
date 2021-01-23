    <ListView PointerEntered="PointerEntered" x:Name="PostListView" >
    ....
    </ListView>
    
    private void PointerEntered(object sender, PointerRoutedEventArgs e)
            {
                listScrollviewer = Scrolling(PostListView);
            }
    
            private ScrollViewer Scrolling(DependencyObject depObj)
            {
                ScrollViewer foundOne = GetScrollViewer(depObj);
                if (foundOne != null)
                {
                    //    if (foundOne.VerticalOffset == 0)
                    //    //refresh.Visibility = Visibility.Visible;
                    //    else
                    //refresh.Visibility = Visibility.Collapsed;
                    foundOne.ViewChanging += foundOne_ViewChanging;
                }
    
    
                return foundOne;
            }
    
            public static ScrollViewer GetScrollViewer(DependencyObject depObj)
            {
                if (depObj is ScrollViewer) return depObj as ScrollViewer;
    
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
    
                    var result = GetScrollViewer(child);
                    if (result != null) return result;
                }
                return null;
            }
          
            private void foundOne_ViewChanging(object sender, ScrollViewerViewChangingEventArgs e)
            {
              //YOur logic to hide the button
              if (e.NextView.VerticalOffset == 0)
                {
                }
               else
               {
                  //Hide the button
               }
            }
