	public class CarStrategy : ICarStrategy
	{
		private readonly ICarFactory[] carFactories;
		public CarStrategy(ICarFactory[] carFactories)
		{
			if (carFactories == null)
				throw new ArgumentNullException("carFactories");
				
			this.carFactories = carFactories;
		}
		
		public ICar CreateCar(Type type)
		{
			var carFactory = this.carFactories
				.FirstOrDefault(factory => factory.AppliesTo(type));
				
			if (carFactory == null)
			{
				throw new Exception("type not registered");
			}
			
			return carFactory.CreateCar();
		}
	}
