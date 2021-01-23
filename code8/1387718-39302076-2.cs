	public partial class Motorcycle : Vehicle
	{
		public static Expression<Func<Vehicle, bool>> IsNew { get { return (v) => v.Age <= 1; } }
	}
	public partial class Car : Vehicle
	{
		public static Expression<Func<Vehicle, bool>> IsNew { get { return (v) => v.Age <= 2; } }
	}
