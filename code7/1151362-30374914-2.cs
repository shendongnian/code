        public IEnumerable<MyElementType> Elements
        {
            get { return (IEnumerable<MyElementType>)GetValue(ElementsProperty); }
            set { SetValue(ElementsProperty, value); }
        }
        public static readonly DependencyProperty ElementsProperty =
            DependencyProperty.Register("Elements", typeof(IEnumerable<MyElementType>), typeof(MyUiUserControlType), new UIPropertyMetadata(null));
