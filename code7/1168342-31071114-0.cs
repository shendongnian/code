    protected override void OnRender(DrawingContext drawingContext)
    {
        if (Height > MyMaxHeight)
            Height = MyMaxHeight;
        base.OnRender(drawingContext);
    }
    protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
    {
        if (Height > MyMaxHeight)
            Height = MyMaxHeight;
        base.OnRenderSizeChanged(sizeInfo);
    }
