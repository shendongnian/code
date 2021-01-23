    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();
        var grid = this.Template.FindName("Grid", this) as FrameworkElement;
        if (grid != null)
        {
            grid.Margin = new Thickness(3, 1, -3, 1);
        }
    }
