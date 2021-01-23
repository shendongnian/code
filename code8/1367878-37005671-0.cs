            private static DependencyProperty _VidTranslateNamesProperty;
    
            public static event EventHandler VidTranslateNamesPropertyChanged;
    
            public static double VidTranslateNamesProperty
            {
                get { return _VidTranslateNamesProperty; }
                set
                {
                    _VidTranslateNamesProperty = value;
                    RaiseVidTranslateNamesPropertyChanged();
                }
            }
    
    
    
            public static void RaiseVidTranslateNamesPropertyChanged()
            {
                EventHandler handler = VidTranslateNamesPropertyChanged;
                if (handler != null)
                    handler(null, new EventArgs.Empty);
            }
