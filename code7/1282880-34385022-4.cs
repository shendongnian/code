	var list = new List<ThreeDPoint> 
	{ 
		new ThreeDPoint(1.0, 2.0, 3.0), 
		new ThreeDPoint(1.0, 2.0, 3.0), 
		new ThreeDPoint(2.0, 2.0, 2.0), 
		new ThreeDPoint(2.0, 2.0, 2.0) 
	};
	
	var distinctResult = list.GroupBy(x => new { x.X, x.Y, x.Z })
							 .Select(x => x.First());
