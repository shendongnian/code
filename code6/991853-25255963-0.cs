        Rectangle rect = new Rectangle()
        {
            Stroke = new SolidColorBrush(Colors.Silver),
            StrokeThickness = 2,
            Fill = new SolidColorBrush(Colors.Transparent),
            Height = cellSize,
            Width = cellSize,
            Style = (cellType != 2) ? PrepareAnimationStyle(cellType) : null
        };
        if (cellType == 2)
            rect.SetValue(AnimationHelper.IsNonRegularCellProperty, true);
        grid.Children.Add(rect);
