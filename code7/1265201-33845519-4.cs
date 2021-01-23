    FrameworkElementFactory canvas = new FrameworkElementFactory(typeof(Canvas));
    canvas.SetValue(Canvas.BackgroundProperty, new SolidColorBrush(Colors.Red));
    
    FrameworkElementFactory tb = new FrameworkElementFactory(typeof(TextBlock));
    Binding binding = new Binding("Content");
    binding.RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent);
    binding.Converter = new Converters.ContentConverter();
    tb.SetBinding(TextBlock.TextProperty, binding);
    
    canvas.AppendChild(tb);
    
    ControlTemplate ct = new ControlTemplate(typeof(Button));
    ct.VisualTree = canvas;
    
    Btn1.Template = ct;
