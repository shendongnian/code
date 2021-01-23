	public class BasePoly
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Width { get; set; }
		public double Height { get; set; }
	}
	
	interface IEntity
	{
		BasePoly GetPoly();
		void InsertPoly(BasePoly poly);
	}
	
	public abstract class Entity : IEntity
	{
		public abstract BasePoly GetPoly();
		public abstract void InsertPoly(BasePoly poly);
	}
	
	public class AutocadEntity : Entity
	{
		public override BasePoly GetPoly()
		{
			// retrieve external type, convert it to BasePoly and return that
			throw new NotImplementedException();
		}
		public override void InsertPoly(BasePoly poly)
		{
			// convert BasePoly to external type and insert that
			throw new NotImplementedException();
		}
	}
	
	public class SketchupEntity : Entity
	{
		public override BasePoly GetPoly()
		{
			// retrieve external type, convert it to BasePoly and return that
			throw new NotImplementedException();
		}
		public override void InsertPoly(BasePoly poly)
		{
			// convert BasePoly to external type and insert that
			throw new NotImplementedException();
		}
	}
	
	// fills for third party classes
	public class PolyLine {}
	public class Face {}
