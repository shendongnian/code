    public class CarFactory
    {
        private readonly Func<Type, ICar> carFactory;
        public CarFactory(Func<Type, ICar> carFactory)
        {
           this.carFactory = carFactory;
        }
        public ICar CreateCar(Type carType)
        {
            return carFactory(carType);
     }
