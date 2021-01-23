            private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var tabControlContentPanel = tb.Template.FindName("ContentPanel", tb) as Border;
            tabControlContentPanel.BorderThickness = new Thickness(10);
            foreach (TabItem tabItem in tb.Items)
            {
                var tabItemHeader = tabItem.Template.FindName("Bd", tabItem) as Border;
                tabItemHeader.BorderThickness = new Thickness(10);
            }
        }
