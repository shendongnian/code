    protected override Size ArrangeOverride(Size finalSize)
    {
        int i = 0;
        foreach( UIElement child in InternalChildern)
        {
            var r = new Rect(this.ActualSize / this.InternalChildren.count * i, 0, this.ActualSize / this.InteralChildren.Count, finalSize.Height);
            child.Arrange( r );
            i++;
        }
    }
