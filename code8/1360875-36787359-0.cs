        public interface ICar
        {
            IEngine Engine { get; set; }
        }
    
        public class Mustang : ICar
        {
            private IEngine _engine = EngineFactory.GetEngine(EngineType.Mustang);
            public IEngine Engine
            {
                get { return _engine; }
                set { _engine = value; }
            }
        } 
    
        public class CarFactory
        {
            public ICar GetCar(CarType carType)
            {
                switch (carType)
                { case CarType.Ford: return new Mustang(); }
            }
        }
