    class PointsComparer : IComparer<List<Point2D>>
	{
		public int Compare(List<Point2D> left, List<Point2D> right)
		{
			for (int i = 0; i < left.Count && i < right.Count; i++) {
				int c = left[i].X.CompareTo(right[i].X);
				if (c != 0) return c;
				c = left[i].Y.CompareTo(right[i].Y);
				if (c != 0) return c;
			}
			return left.Count.CompareTo(right.Count);
		}
	}
    polygons.OrderBy(poly => poly.Points, new PointsComparer());
