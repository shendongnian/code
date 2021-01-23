	namespace Weingartner.Numerics.Geometry
	{
	
	    /// <summary>
	    /// Find the smallest enclosing circle. See reference
	    /// http://www.inf.ethz.ch/personal/emo/PublFiles/SmallEnclDisk_LNCS555_91.pdf
	    /// "Smallest enclosing disks (balls and ellipsoids) EMO WELZL
	    /// </summary>
	    /// <returns></returns>
	    public static class Circles 
	    {
	        private static Return<Circle> Left
	            (List<Point2D> points, List<Point2D> boundary)
	        {
	
	            if ( !points.Any() || boundary.Count == 3 )
	            {
	                if ( boundary.Count <= 1 )
	                {
	                    return Return.Value<Circle>(null);
	                }
	
	                if ( boundary.Count == 2 )
	                {
	                    var radius = boundary[0].DistanceTo(boundary[1]) / 2;
	                    var center = ( boundary[0] + boundary[1] ) * 0.5;
	                    return Return.Value(new Circle(Plane.XY, center, radius));
	                }
	
	                return Return.Value(new Circle(Plane.XY, boundary[0], boundary[1], boundary[2]));
	            }
	
	            var p = points[0];
	            var q = points.GetRange(1, points.Count - 1);
	
	            return Return.Call
	                ( () => Left(q, boundary)
	                , circle =>
	                  {
	                       if ( circle == null || circle.Center.DistanceTo(p) >= circle.Radius )
	                       {
	                           return Return.Call(() => Left(q, boundary.Concat(p).ToList()));
	                       }
	                       return Return.Value(circle);
	                  });
	        }
	
	        public static Circle MiniDisk( List<Point2D> points )
	        {
	            points = points.Slice(0);
	            points.Shuffle();
	            return TrampolineRecursion.Do(()=>Left(points, new List<Point2D>()));
	        }
	
	    }
	
	}
