	public class PointGetter
	{
		public Point GetLastPoint(DbContext dbContext, Device device)
		{
			var lastPointForDevice = dbContext.Points
											  .Where(p => p.Device == device)
											  .OrderByDescending(p => p.FixTime)
											  .FirstOrDefault();
			return lastPointForDevice;
		}
	}
