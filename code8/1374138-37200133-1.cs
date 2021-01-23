    public class MyCustomControl : ContentControl
        {
            static MyCustomControl()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomControl), new FrameworkPropertyMetadata(typeof(MyCustomControl)));  
            }
    
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
            }
    
            public object Info
            {
                get { return (object)GetValue(InfoProperty); }
                set { SetValue(InfoProperty, value); }
            }
    
            public DataTemplate InfoTemplate
            {
                get { return (DataTemplate)GetValue(InfoTemplateProperty); }
                set { SetValue(InfoTemplateProperty, value); }
            }
    
            public static readonly DependencyProperty InfoProperty =
                DependencyProperty.Register(nameof(Info), typeof(object), typeof(MyCustomControl), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(MyCustomControl.OnHeaderChanged)));
    
            private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var obj = (MyCustomControl)d; 
                obj.RemoveLogicalChild(e.OldValue);
                obj.AddLogicalChild(e.NewValue);
            }
    
            public static readonly DependencyProperty InfoTemplateProperty =
                DependencyProperty.Register(nameof(InfoTemplate), typeof(DataTemplate), typeof(MyCustomControl), new PropertyMetadata(null));
        }
