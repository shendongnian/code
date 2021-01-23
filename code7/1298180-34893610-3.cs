    public static readonly DependencyProperty FontWeightSelectorProperty =
    DependencyProperty.Register("FontWeightSelector", typeof(WeightList.FontWeightList), typeof(ControlClass), new UIPropertyMetadata(WeightList.FontWeightList.Normal));
    
    public WeightList.FontWeightList FontWeightSelector
    {
        get { return (WeightList.FontWeightList)GetValue(FontWeightSelectorProperty); }
        set { SetValue(FontWeightSelectorProperty, value); }
    }
