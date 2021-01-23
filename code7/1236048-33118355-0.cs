    public static readonly DependencyProperty LContentProperty =
            DependencyProperty.Register("LabelContent", typeof(string), typeof(MainWindow));
        public string LabelContent
        {
            get { return (string)GetValue(LContentProperty); }
            set { SetValue(LContentProperty, value); }
        }
