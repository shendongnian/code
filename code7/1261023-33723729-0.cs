    private void lstEvents_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ListBoxItem lbi = (lstEvents.ItemContainerGenerator.ContainerFromIndex(lstEvents.SelectedIndex)) as ListBoxItem;
                ContentPresenter cp = GetFrameworkElementByName<ContentPresenter>(lbi);
                DataTemplate dt = lstEvents.ItemTemplate;
                Label l = (dt.FindName("lblEventId", cp)) as Label;
                MessageBox.Show(l.Content.ToString());   
            }
