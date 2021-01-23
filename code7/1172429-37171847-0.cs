    /// <summary>
    /// Get the ItemsHolder and generate any children
    /// </summary>
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        itemsHolderPanel = new Grid();
        // exchange ContentPresenter for Grid
        var topGrid = (Grid)GetVisualChild(0);
        var border = (Border)topGrid.Children[1];
        border.Child = itemsHolderPanel;
        UpdateSelectedItem();
    }
    /// <summary>
    /// Create Grid in code behind instead of defining own style.
    /// </summary>
    private Grid CreateGrid()
    {
        var grid = new Grid();
        Binding binding = new Binding(PaddingProperty.Name);
        binding.Source = this;  // view model?
        grid.SetBinding(Grid.MarginProperty, binding);
        binding = new Binding(SnapsToDevicePixelsProperty.Name);
        binding.Source = this;  // view model?
        grid.SetBinding(Grid.SnapsToDevicePixelsProperty, binding);
        return grid;
    }
