        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomControl cc = d as CustomControl;
            string content = (string)e.NewValue;
            cc.TextBlockContent = content;
        }
