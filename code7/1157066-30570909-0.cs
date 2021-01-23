    [ToolboxItem(false)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BrushProperties
    {
      public Color[] GradientColors { get; set; }
      public Single[] GradientPositions { get; set; }
      public Single GradientAngle { get; set; }
    }
    [ToolboxItem(false)]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Style
    {
      public BrushProperties Background { get; set; }
      public BrushProperties Foreground { get; set; }
      public Style()
      {
        this.Background = new BrushProperties();
        this.Foreground = new BrushProperties();
      }
    }    
