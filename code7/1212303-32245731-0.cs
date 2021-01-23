            var line = new Line();
            line.Stroke = new SolidColorBrush(Colors.Black);
            line.StrokeThickness = 3;
            //line.Width = 50;
            line.X1 = 0;
            line.Y1 = 0;
            line.X2 = 50;
            line.Y2 = 0;
            Canvas.SetTop(line, 50);
            Canvas.SetLeft(line, 50);
            
        
            TheCanvas.Children.Add(line);
