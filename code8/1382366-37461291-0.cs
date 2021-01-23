	protected override void OnRender(DrawingContext drawingContext)
	{
		double radiusX = RenderSize.Width / 2;
		double radiusY = RenderSize.Height/2;
		PathGeometry clip = GetArcGeometry().GetWidenedPathGeometry(
            new Pen(Stroke, StrokeThickness));
		drawingContext.PushClip(clip);
		drawingContext.DrawEllipse(Stroke, null, new Point(radiusX, radiusY), radiusX,radiusY);
		drawingContext.Pop();
	}
