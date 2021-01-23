	protected override void OnRender(DrawingContext drawingContext)
	{
        // half the width and height of the Arc
		double radiusX = RenderSize.Width / 2;
		double radiusY = RenderSize.Height/2;
        // the outlines of the "original" Arc geometry
		PathGeometry clip = GetArcGeometry().GetWidenedPathGeometry(
            new Pen(Stroke, StrokeThickness));
        // draw only in the area of the original arc
		drawingContext.PushClip(clip);
		drawingContext.DrawEllipse(Stroke, null, new Point(radiusX, radiusY), radiusX,radiusY);
		drawingContext.Pop();
	}
