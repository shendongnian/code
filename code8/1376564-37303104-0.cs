     public bool GpoAnimationLocked
        {
            get { return (bool)GetValue(GpoAnimationLockedProperty); }
            set { SetValue(GpoAnimationLockedProperty, value); }
        }
        public static readonly DependencyProperty GpoAnimationLockedProperty =
            DependencyProperty.Register("GpoAnimationLocked", typeof(bool),
                typeof(ModuleIndicator), new UIPropertyMetadata(true));
        public bool GpoModule {
            get { return (bool)GetValue(GpoModuleProperty); }
            set { SetValue(GpoModuleProperty, value); }
        }
        public static readonly DependencyProperty GpoModuleProperty =
            DependencyProperty.Register("GpoModule", typeof(bool),
                typeof(ModuleIndicator), new UIPropertyMetadata(false, GpoSelectionPropertyChanged));
        protected virtual void GpoSelectionChanged(DependencyPropertyChangedEventArgs e) {
            GpoAnimationLocked = false;
        }
        private static void GpoSelectionPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e) {
            ((ModuleIndicator)sender).GpoSelectionChanged(e);
        }
