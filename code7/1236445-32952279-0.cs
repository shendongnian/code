	Geometry geo = .... ;
	IEnumerable<PolyLineSegment> segments =
		from PathFigure figure in geo.GetOutlinedPathGeometry().Figures
		from PathSegment segment in figure.Segments
		select s as PolyLineSegment;
	using (GraphicsPath path = new GraphicsPath())
	{
		path.StartFigure();
		
		foreach (PolyLineSegment plseg in segments)
		{
			PointF[] points = (from point in plseg.Points
							   select new Point((float)point.X, (float)point.Y)).ToArray();
		
			path.AddPolygon(points);
		}
		
		path.CloseFigure();
		
		// DO SOMETHING WITH `path´
	}
