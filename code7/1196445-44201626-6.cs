    private void SlitViewPaneButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var frame = contentFrame;
            Page page = frame?.Content as Page;
            if (page?.GetType() != typeof(ChildPage))
            {              
                frame.Navigate(typeof(ChildPage), SplitViewName);
            }
        }
