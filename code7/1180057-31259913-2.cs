	public struct ReadOnlyVector3 : IReadOnlyVector
	{
		public double X { get; private set; }
		public double Y { get; private set; }
		public double Z { get; private set; }   
	}
	
	public interface IReadOnlyVector
	{
		double X { get; }
		double Y { get; }
		double Z { get; }
	}
