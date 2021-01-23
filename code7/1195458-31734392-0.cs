      public static readonly BindableProperty IsCheckedProperty = 
        BindableProperty.Create<CheckBox, bool> (w => w.IsChecked, false);
    
      public bool IsChecked{
        get { return GetValue (FooProperty); }
        set { SetValue (FooProperty, value); } 
      }
