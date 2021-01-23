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
                //do whatever you want
            }
        }
