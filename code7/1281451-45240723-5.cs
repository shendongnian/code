    public class Solver : ISolve
        {
            private UnityContainer _container = new UnityContainer();
            public Solver()
            {
                /* Using Unity "Framework to do Dependency Injection" it is possible do register a type.
                 When the method 'Solve' is called, the container looks for a implemented class that inherits
                 methods from a certain interface passed by parameter and returns an instantiated object.
                 */
                _container.RegisterType<IFight,Fight>();
            }
    
            //This is where the magic happens
            public T Solve<T>()
            {
                return _container.Resolve<T>();
            }
