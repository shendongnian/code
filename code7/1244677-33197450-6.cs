        public static readonly DependencyProperty OnExpandedActionProperty = DependencyProperty.Register(
            "OnExpandedAction", typeof (Action<object,RoutedEventArgs>), typeof (TreeViewItemExpandBehavior), new PropertyMetadata(default(Action<object,RoutedEventArgs>)));
        public Action<object,RoutedEventArgs> OnExpandedAction
        {
            get { return (Action<object,RoutedEventArgs>) GetValue(OnExpandedActionProperty); }
            set { SetValue(OnExpandedActionProperty, value); }
        }
