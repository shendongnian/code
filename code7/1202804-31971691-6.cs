	public class Car1Factory : ICarFactory
	{
		private readonly IDep1 dep1;
		private readonly IDep2 dep2;
		private readonly IDep3 dep3;
		
		public Car1Factory(IDep1 dep1, IDep2 dep2, IDep3 dep3)
		{
			if (dep1 == null)
				throw new ArgumentNullException("dep1");
			if (dep2 == null)
				throw new ArgumentNullException("dep2");
			if (dep3 == null)
				throw new ArgumentNullException("dep3");
				
			this.dep1 = dep1;
			this.dep2 = dep2;
			this.dep3 = dep3;
		}
		
		public ICar CreateCar()
		{
			return new Car1(this.dep1, this.dep2, this.dep3);
		}
		
		public bool AppliesTo(Type type)
		{
			return typeof(Car1).Equals(type);
		}
	}
	public class Car2Factory : ICarFactory
	{
		private readonly IDep4 dep4;
		private readonly IDep5 dep5;
		private readonly IDep6 dep6;
		
		public Car1Factory(IDep4 dep4, IDep5 dep5, IDep6 dep6)
		{
			if (dep4 == null)
				throw new ArgumentNullException("dep4");
			if (dep5 == null)
				throw new ArgumentNullException("dep5");
			if (dep6 == null)
				throw new ArgumentNullException("dep6");
				
			this.dep4 = dep4;
			this.dep5 = dep5;
			this.dep6 = dep6;
		}
		
		public ICar CreateCar()
		{
			return new Car2(this.dep4, this.dep5, this.dep6);
		}
		
		public bool AppliesTo(Type type)
		{
			return typeof(Car2).Equals(type);
		}
	}
