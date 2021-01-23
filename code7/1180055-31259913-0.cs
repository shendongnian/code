	public struct Vector3 : IVector
	{
		public double X { get; set; }
		public double Y { get; set; }
		public double Z { get; set; }   
	}
	
	public interface IVector
	{
		double X { get; set; }
		double Y { get; set; }
		double Z { get; set; }  
	}
