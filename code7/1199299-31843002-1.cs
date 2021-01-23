     public override void OnApplyTemplate()
    {
        Border border = VisualTreeHelperExtensions.FindVisualChild<Border>(this,"Background") as Border;
        border.CornerRadius = this.CornerRadius;
    }
