    public void getPosition(UIElement element, out int col, out int row)
        {
            DControl control = parent as DControl;
            var point = Mouse.GetPosition(element);
            row = 0;
            col = 0;
            double accumulatedHeight = 0.0;
            double accumulatedWidth = 0.0;
            // calc row mouse was over
            foreach (var rowDefinition in control.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= point.Y)
                    break;
                row++;
            }
            // calc col mouse was over
            foreach (var columnDefinition in control.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= point.X)
                    break;
                col++;
            }
        }
