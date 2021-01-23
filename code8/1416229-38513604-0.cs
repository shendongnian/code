    // <summary>
    /// Holds the parent VM here.
    /// </summary>
    public MainVM ParentVM
    {
        get { return GetValue(ParentVMProperty) as MainVM; }
        set { SetValue(ParentVMProperty, value); }
    }
    
        /// <summary>
        /// Identifies the ParentVM dependency property.
        /// </summary>
        public static readonly System.Windows.DependencyProperty ParentVMProperty =
            System.Windows.DependencyProperty.Register(
                "ParentVM",
                typeof(MainVM),
                typeof({Insert Control1 or 2 class type here}),
                new System.Windows.PropertyMetadata(null, OnParentVMPropertyChanged));
        
        /// <summary>
        /// ParentVMProperty property changed handler.
        /// </summary>
        /// <param name="d">BeginRandom that changed its ParentVM.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnParentVMPropertyChanged(System.Windows.DependencyObject d, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            var source = d as {Insert Control1 or 2 class type here};
            MainVM value = e.NewValue as MainVM;
        }
