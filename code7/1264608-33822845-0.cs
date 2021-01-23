        public readonly static DependencyProperty IsBusyProperty = DependencyProperty.Register(
        "IsBusy", typeof(bool), typeof(BusyControl), new PropertyMetadata(false));
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }
