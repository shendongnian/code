    public static readonly DependencyProperty ListLengthProperty =
            DependencyProperty.Register("ListLength", typeof(string), typeof(Window), new PropertyMetadata(null));
        public string ListLength
        {
            get { return (string)GetValue(ListLengthProperty); }
            set { SetValue(ListLengthProperty, value); }
        }
