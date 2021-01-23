    button.Click += (sender,e) => 
        {
            if (button.Visibility == Visibility.Visible)
                button.Visibility = Visibility.Collapsed;
            else
                button.Visibility = Visibility.Visible;
        };
