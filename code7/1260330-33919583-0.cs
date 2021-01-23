    protected override Size ArrangeOverride(Size finalSize)
    {
        foreach(UIElement child in InternalChildren.OfType<UIElement>()
            .Where(e => !GetIsLabel(e))
            .OrderByDescending(GetZIndex))
        {
            Rect plotArea = PositionByCanvasLocationOrIgnore(child, finalSize);
            ContentPresenter labelPresenter = GetLabelPresenter(child);
            Rect labelRect = new Rect(labelPresenter.DesiredSize)
            {
                X = plotArea.Right + LabelOffset,
                Y = plotArea.Y + ((plotArea.Height - labelPresenter.DesiredSize.Height) / 2)
            };
            labelPresenter.Arrange(labelRect);
        }
        // NEW CODE: force the visual to be redrawn every time.
        InvalidateVisual();
        return finalSize;
    }
