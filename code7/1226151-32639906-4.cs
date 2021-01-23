        public static readonly DependencyProperty TextHeaderProperty = DependencyProperty.Register(
            "TextHeader", 
            typeof(string), 
            typeof(StyledPanel), 
            new PropertyMetadata(TextHeaderPropertyChanged));
        private static void TextHeaderPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var instance = sender as StyledPanel;
            if (String.IsNullOrEmpty(instance.TextHeader))
            {
                instance.lTitle.Visibility = Visibility.Hidden;
                instance.iSeparator.Visibility = Visibility.Hidden;
            }
            else
            {
                instance.lTitle.Content = _Header;
                instance.lTitle.Visibility = Visibility.Visible;
                instance.iSeparator.Visibility = Visibility.Visible;
            }
        }
