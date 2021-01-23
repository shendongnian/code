 	public class Projectile
	{
		public VECTOR position { get; private set; }		
		
		public Projectile()
		{
			position = new VECTOR();
		}
	}
	
	public struct VECTOR 
	{
		public double x {get; set;}	
	}
