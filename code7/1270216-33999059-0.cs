    public static readonly DependencyProperty EnterKeyProperty = 
            DependencyProperty.RegisterAttached("EnterKey", typeof(ICommand), typeof(TextBoxExtension), new UIPropertyMetadata(EnterKeyPropertyChanged));
    
    
    public static ICommand GetEnterKey(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(EnterKeyProperty);
        }
    
        public static void SetEnterKey(DependencyObject obj, ICommand value)
        {
            obj.SetValue(EnterKeyProperty, value);
        }
