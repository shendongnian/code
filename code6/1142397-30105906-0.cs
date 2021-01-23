        #region SomeProperty
        /// <summary>
        /// The <see cref="DependencyProperty"/> for <see cref="SomeProperty"/>.
        /// </summary>
        public static readonly DependencyProperty SomePropertyProperty =
            DependencyProperty.Register(
                SomePropertyPropertyName,
                typeof(object),
                typeof(MainWindow),
                new UIPropertyMetadata(null, OnSomePropertyPropertyChanged));
        /// <summary>
        /// Called when the value of <see cref="SomePropertyProperty"/> changes on a given instance of <see cref="MainWindow"/>.
        /// </summary>
        /// <param name="d">The instance on which the property changed.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSomePropertyPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as MainWindow).OnSomePropertyChanged(e.OldValue as object, e.NewValue as object);
        }
        /// <summary>
        /// Called when <see cref="SomeProperty"/> changes.
        /// </summary>
        /// <param name="oldValue">The old value</param>
        /// <param name="newValue">The new value</param>
        private void OnSomePropertyChanged(object oldValue, object newValue)
        {
            ;
        }
        /// <summary>
        /// The name of the <see cref="SomeProperty"/> <see cref="DependencyProperty"/>.
        /// </summary>
        public const string SomePropertyPropertyName = "SomeProperty";
        /// <summary>
        /// 
        /// </summary>
        public object SomeProperty
        {
            get { return (object)GetValue(SomePropertyProperty); }
            set { SetValue(SomePropertyProperty, value); }
        }
        #endregion  
