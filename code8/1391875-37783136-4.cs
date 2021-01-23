    void Current_SizeChanged(object sender, Window.UI.Core.WindowSizeChangedEventArgs e)
    {
      var b=Window.Current.Bounds;
         if (b.Width>b.Height)
            {
                FruitGridView.ItemTemplate = (DataTemplate)Resources["TemplateHori"];
            }
            else
            {
                FruitGridView.ItemTemplate = (DataTemplate)Resources["TemplateVerti"];     
            }
    }
