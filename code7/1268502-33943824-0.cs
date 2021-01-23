    FrameworkElementFactory grid = new FrameworkElementFactory(typeof(Grid));
                
    FrameworkElementFactory image = new FrameworkElementFactory(typeof(Image));
    image.Name = "PART_Track";
    ImageSource source = new BitmapImage(...); // create it
    image.SetValue(Image.SourceProperty, source);
    image.SetValue(Image.StretchProperty, Stretch.Fill);
    
    grid.AppendChild(image);
    
    FrameworkElementFactory rectangle = new FrameworkElementFactory(typeof(Rectangle));
    rectangle.Name = "PART_Indicator";
    rectangle.SetValue(Rectangle.FillProperty, new SolidColorBrush(Colors.BlanchedAlmond));
    rectangle.SetValue(Rectangle.HorizontalAlignmentProperty, HorizontalAlignment.Left);
    
    grid.AppendChild(rectangle);
    
        ControlTemplate ct = new ControlTemplate(typeof(ProgressBar));
    ct.VisualTree = grid;
    
    MyProgressBar1.Template = ct;
