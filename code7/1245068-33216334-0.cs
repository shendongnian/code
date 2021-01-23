    public static class Image
    {
      // color stuff goes here
      ... 
      public static readonly DependencyProperty SourceProperty = DependencyProperty.RegisterAttached("Source", typeof(MaterialImage), typeof(Image), new FrameworkPropertyMetadata(MaterialImage.Mood, OnSourceChangedCallback));
      public static MaterialImage GetSource(DependencyObject element) { return (MaterialImage)element.GetValue(Image.SourceProperty); }
      public static void SetSource(DependencyObject element, MaterialImage value) { element.SetValue(Image.SourceProperty, value); }
      private static void OnSourceChangedCallback(DependencyObject source, DependencyPropertyChangedEventArgs args)
      {
         var image = (System.Windows.Controls.Image)source;
         if (args.NewValue == null)
         {
            image.Source = null;
            return;
         }
         var resourceName = string.Format("Material{0}", args.NewValue);
         if (!Application.Current.Resources.Contains(resourceName))
         {
            image.Source = null;
            return;
         }
         image.Source = Application.Current.Resources[resourceName] as DrawingImage;
      }
    }
