        public static readonly DependencyProperty SalutationProperty =
           DependencyProperty.RegisterAttached("Salutation",
                typeof(string),
                typeof(MyHyperLinkBehavior),
                new PropertyMetadata(OnSalutationPropertyChanged));
        private static void OnSalutationPropertyChanged(object sender,
                                                 DependencyPropertyChangedEventArgs e)
        {
             //attach to event handlers (Click, Loaded, etc...)
        }
