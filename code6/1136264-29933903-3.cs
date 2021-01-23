    private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        DependencyObject clickedObj = (DependencyObject)e.OriginalSource;
        while (clickedObj != null && clickedObj != listDiscussion)
        {
            if (clickedObj.GetType() == typeof(ListViewItem))
            {
                Discussion selectedDiscussion =
                    (Discussion)listDiscussion.ItemContainerGenerator
                        .ItemFromContainer((ListViewItem)listDiscussion.SelectedItem);
                this.NavigationService.Navigate(new MessagePage(selectedDiscussion));
                break;
            }
            clickedObj = VisualTreeHelper.GetParent(clickedObj);
        }
    }
