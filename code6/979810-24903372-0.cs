    private void Button_Click(object sender, RoutedEventArgs e)
            {
                lviewThumbnails.Visibility = Visibility.Visible;
    
                int index = 75;
                ThumbsCollection[index].IsFocus = true;
    
                Button button = (Button)FindFirstVisualChild(lviewThumbnails, "pageThumbnail");
    
                lviewThumbnails.ScrollToHorizontalOffset((button.ActualWidth + 6.5) * index); // set it with pageThumbnail's location or margin
            }
    
            public object FindFirstVisualChild(DependencyObject obj, string childName)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                    if (child != null && child.GetValue(NameProperty).ToString() == childName)
                    {
                        return child;
                    }
                    else
                    {
                        object childOfChild = FindFirstVisualChild(child, childName);
                        if (childOfChild != null)
                        {
                            return childOfChild;
                        }
                    }
                }
                return null;
            }
