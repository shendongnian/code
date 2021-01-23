    FrameworkElementFactory canvas = new FrameworkElementFactory(typeof(Canvas));
                canvas.Name = "PlotArea";
    
                FrameworkElementFactory path = new FrameworkElementFactory(typeof(Path));
                {                
                    path.SetValue(Path.StrokeThicknessProperty, 1.5);
                    path.SetValue(Path.StrokeProperty, new SolidColorBrush(Colors.Green));
                    path.SetValue(Path.OpacityProperty, 0.25);
    
                    MultiBinding binding = new MultiBinding();
                    // create your converter properly below
                    binding.Converter = new Converters.GeoConverter();
    
                    Binding bindingItem1 = new Binding();
                    bindingItem1.ElementName = "AreaPlus1SD";
                    bindingItem1.Path = new PropertyPath("Geometry");
    
                    Binding bindingItem2 = new Binding();
                    bindingItem2.ElementName = "AreaMedian";
                    bindingItem2.Path = new PropertyPath("Geometry");
    
                    binding.Bindings.Add(bindingItem1);
                    binding.Bindings.Add(bindingItem2);
    
                    path.SetBinding(Path.DataProperty, binding);
                }
    
                canvas.AppendChild(path);
    
                ControlTemplate ct = new ControlTemplate(typeof(ChartingToolkit.AreaSeries));
                ct.VisualTree = canvas;
    
               AreaSeries1.Template = canvas;
