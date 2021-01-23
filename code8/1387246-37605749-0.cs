            StackPanel sp = new StackPanel();
            sp.Orientation = Orientation.Vertical;
            Line line = new Line();
            line.X1 = 0;
            var bind = new Binding()
            {
                Source = sp,
                Path = new PropertyPath("ActualWidth")
            };
            BindingOperations.SetBinding(line, Line.X2Property, bind);
            line.StrokeThickness = 2;
            line.Stroke=Brushes.Black;
            line.Margin=new Thickness(10);
            sp.Children.Add(line);
