        protected override void OnRender(DrawingContext drawingContext)
        {
			Rect adornedElementRect = new Rect(this.AdornedElement.DesiredSize);
			Pen renderPen = new Pen(new SolidColorBrush(Colors.Blue), 1);
			double halfPenWidth = renderPen.Thickness / 2;
			GuidelineSet guidelines = new GuidelineSet();
			guidelines.GuidelinesX.Add(adornedElementRect.TopLeft.X + halfPenWidth);
			guidelines.GuidelinesX.Add(adornedElementRect.BottomRight.X + halfPenWidth);
			guidelines.GuidelinesY.Add(adornedElementRect.TopLeft.Y + halfPenWidth);
			guidelines.GuidelinesY.Add(adornedElementRect.BottomRight.Y + halfPenWidth);
			drawingContext.PushGuidelineSet(guidelines);
			if (IsInUpperHalf)
			{
				drawingContext.DrawLine(renderPen, adornedElementRect.TopLeft, adornedElementRect.TopRight);
				StreamGeometry leftStreamGeometry = new StreamGeometry();
				using (StreamGeometryContext geometryContext = leftStreamGeometry.Open())
				{
					geometryContext.BeginFigure(adornedElementRect.TopLeft, true, true);
					geometryContext.LineTo(new Point(adornedElementRect.TopLeft.X + 10, adornedElementRect.TopLeft.Y), false, false);
					geometryContext.LineTo(new Point(adornedElementRect.TopLeft.X, adornedElementRect.TopLeft.Y + 3), false, false);
					drawingContext.DrawGeometry(Brushes.Blue, new Pen(Brushes.Blue, 1), leftStreamGeometry);
				}
				StreamGeometry rigthStreamGeometry = new StreamGeometry();
				using (StreamGeometryContext geometryContext = rigthStreamGeometry.Open())
				{
					geometryContext.BeginFigure(adornedElementRect.TopRight, true, true);
					geometryContext.LineTo(new Point(adornedElementRect.TopRight.X, adornedElementRect.TopRight.Y + 3), false, false);
					geometryContext.LineTo(new Point(adornedElementRect.TopRight.X - 10, adornedElementRect.TopRight.Y), false, false);
					drawingContext.DrawGeometry(Brushes.Blue, new Pen(Brushes.Blue, 1), rigthStreamGeometry);
				}
			}
        }
