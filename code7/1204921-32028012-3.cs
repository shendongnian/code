	public abstract class BasePoly
	{
		public abstract double X { get; set; }
		public abstract double Y { get; set; }
		public abstract double Width { get; set; }
		public abstract double Height { get; set; }
	}
	public abstract class BasePoly<T> : BasePoly
	{
		public T poly { get; private set; }
		protected BasePoly(T poly) { this.poly = poly; }
	}
	
	public class PolyLineAdapter : BasePoly<PolyLine>
	{
		public PolyLineAdapter(PolyLine poly) : base(poly) {}
		// override abstracts and forward to inner PolyLine instance at 'this.poly'
	
		public override double X { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
		public override double Y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
		public override double Width { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
		public override double Height { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
	}
	
	public class FaceAdapter : BasePoly<Face>
	{
		public FaceAdapter(Face poly) : base(poly) {}
		// override abstracts and forward to inner Face instance at 'this.poly'
	
		public override double X { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
		public override double Y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
		public override double Width { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
		public override double Height { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
	
	
	}
	
	interface IEntity
	{
		BasePoly GetPoly();
		void   InsertPoly(BasePoly poly);
	}
	
	public abstract class Entity<TEntity> where TEntity : BasePoly
	{
		TEntity GetPoly()
		{
			//calling third party APIs by calling abstract methods to be implemented by specific provider
			// return Autocad Polyline object
			throw new NotImplementedException();
		}
		void InsertPoly(TEntity poly){ throw new NotImplementedException(); }
	}
	
	public class AutocadEntity : Entity<PolyLineAdapter>
	{
	}
	
	public class SketchupEntity : Entity<FaceAdapter>
	{
	}
	
	// fills for third party classes
	public class PolyLine {}
	public class Face {}
