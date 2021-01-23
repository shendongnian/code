    void KeepInViewBehaviorVisibleBoundsChanged(ApplicationView sender, object args)
    {
      UpdateBottomMargin();
    }
    private void UpdateBottomMargin()
    {
      if (WindowHeight > 0.01)
      {
        var currentMargins = AssociatedObject.Margin;
        var newMargin = new Thickness(
          currentMargins.Left, currentMargins.Top, currentMargins.Right,
          originalBottomMargin + 
            (WindowHeight - ApplicationView.GetForCurrentView().VisibleBounds.Bottom));
        AssociatedObject.Margin = newMargin;
      }
    }
