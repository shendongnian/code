     public static readonly DependencyProperty TextInUserControlProperty =
        DependencyProperty.Register("TextInUserControl",
            typeof(string),
            typeof(UserControl1),new PropertyMetadata("Text"));
        public string TextInUserControl
        {
            get { return (string)GetValue(TextInUserControlProperty); }
            set { SetValue(TextInUserControlProperty, value); }
        }
