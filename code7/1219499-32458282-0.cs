    private void Border_OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
    {
        var border = (Border)sender;
        var currentProjection = border.Projection as PlaneProjection ?? new PlaneProjection();
        border.Projection = new PlaneProjection() { GlobalOffsetX = currentProjection.GlobalOffsetX + e.Delta.Translation.X, GlobalOffsetY =  currentProjection.GlobalOffsetY + e.Delta.Translation.Y };
    }
