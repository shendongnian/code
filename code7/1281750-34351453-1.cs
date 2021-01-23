            TextBlock text = null;
            var stackPanel = new StackPanel();
            stackPanel.Children.Add(text);
            var sv = new ScrollViewer { Content = stackPanel };
            this.Content.Children.Add(sv);
        
