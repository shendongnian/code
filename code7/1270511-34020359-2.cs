    public static readonly DependencyProperty HitProperty = DependencyProperty.Register(
      "Hit",
      typeof(string),
      typeof(UnitBar),
      new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, EmpNamePropertyChanged)
    );
    public string Hit
    {
      get { return (string)GetValue(HitProperty); }
      set { SetValue(HitProperty, value); }
    }
