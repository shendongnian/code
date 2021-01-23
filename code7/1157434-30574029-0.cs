    public static readonly DependencyProperty AquariumGraphicProperty = DependencyProperty.Register(
      "AquariumGraphic",
      typeof(Uri),
      typeof(AquariumObject),
      new FrameworkPropertyMetadata(null,
          FrameworkPropertyMetadataOptions.AffectsRender, 
          new PropertyChangedCallback(OnUriChanged)
      )
    );
    
    private static void OnUriChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
      Shape sh = (Shape) d;
      sh.Fill = new ImageBrush(new BitmapImage((Uri)e.NewValue));
    }
