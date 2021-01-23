        public class DataContextProxy: Freezable
        {
            public DataContextProxy()
            {
                BindingOperations.SetBinding(this, DataContextProperty, new Binding());
            }
    
            public object DataContext
            {
                get { return GetValue(DataContextProperty); }
                set { SetValue(DataContextProperty, value); }
            }
    
            public static readonly DependencyProperty DataContextProperty = FrameworkElement
                .DataContextProperty.AddOwner(typeof (DataContextProxy));
    
            protected override Freezable CreateInstanceCore()
            {
                return new DataContextProxy();
            }
        }
