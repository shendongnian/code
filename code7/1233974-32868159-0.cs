    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Localizability(LocalizationCategory.NeverLocalize)]
    public object DataContext
    {
      get
      {
        return this.GetValue(FrameworkElement.DataContextProperty);
      }
      set
      {
        this.SetValue(FrameworkElement.DataContextProperty, value);
      }
    }
...
        public static readonly DependencyProperty DataContextProperty = 
    DependencyProperty.Register("DataContext", typeof (object...
