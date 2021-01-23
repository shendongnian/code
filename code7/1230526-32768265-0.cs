       private void spContentPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadTemplate();
            if (spContentPanel.Children != null && spContentPanel.Children[0] != null)
            {
                templateRoot = (FrameworkElement) spContentPanel.Children[0];
                templateRoot.Width = spContentPanel.ActualWidth;
                templateRoot.Height = spContentPanel.ActualHeight;
                templateRoot.UpdateLayout();
            }
        }
