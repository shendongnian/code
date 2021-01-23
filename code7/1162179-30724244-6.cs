    private static double ComputeGridSizeForStarWidths(Grid grid)
    {
        double maxTargetWidth = double.MinValue, otherWidth = 0;
        double starTotal = grid.ColumnDefinitions
            .Where(d => d.Width.IsStar).Sum(d => d.Width.Value);
        foreach (ColumnDefinition definition in grid.ColumnDefinitions)
        {
            if (!definition.Width.IsStar)
            {
                otherWidth += definition.ActualWidth;
                continue;
            }
            double targetWidth = definition.ActualWidth / (definition.Width.Value / starTotal);
            if (maxTargetWidth < targetWidth)
            {
                maxTargetWidth = targetWidth;
            }
        }
        return otherWidth + maxTargetWidth;
    }
