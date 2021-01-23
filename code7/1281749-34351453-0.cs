        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var textBlock = new TextBlock() { Text = "hello" };
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(textBlock);
            var sv = new ScrollViewer { Content = stackPanel };
            this.Content.Children.Add(sv);
        }
