       public StatusUpdate CurrentStatus
            {
                get { return (StatusUpdate)GetValue(CurrentStatusProperty); }
                set { SetValue(CurrentStatusProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for CurrentStatus.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty CurrentStatusProperty =
                DependencyProperty.Register("CurrentStatus", typeof(StatusUpdate), typeof(UCStatusBar), 
                    new PropertyMetadata(
                            new StatusUpdate() {  ErrorMessage="", IsIndeterminate=false, Status="Ready"}
                            )
                    );
