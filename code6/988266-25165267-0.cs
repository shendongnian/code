    public static void ZoomToRatio(double ratio)
    {
       ScaleTransform transform = new ScaleTransform()
       {
          ScaleX = ratio,
          ScaleY = ratio,
       };
    
       double height = 0.0;
       double width = 0.0;
    
       if (ratio < 1.0)
       {
          height = Application.Current.Host.Content.ActualHeight * ratio;
          width = Application.Current.Host.Content.ActualWidth * ratio;
       }
       else
       {
          height = Application.Current.Host.Content.ActualHeight / ratio;
          width = Application.Current.Host.Content.ActualWidth / ratio;          
       }
    
       Application.Current.RootVisual.SetValue(Canvas.HeightProperty, height);
       Application.Current.RootVisual.SetValue(Canvas.WidthProperty, width);
       Application.Current.RootVisual.RenderTransform = transform;
    }
