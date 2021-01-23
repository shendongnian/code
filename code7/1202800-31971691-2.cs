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
			var factory = this.carFactories
				.FirstOrDefault(factory => factory.AppliesTo(type));
				
			if (factory == null)
			{
				throw new Exception("type not registered");
			}
			
			return factory.CreateCar();
		}
	}
