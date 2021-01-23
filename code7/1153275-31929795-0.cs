    public class ControllerFactoryDecorator : IControllerFactory
    {
        public ControllerFactoryDecorator(
            IControllerFactory controllerFactory
            )
        {
            if (controllerFactory == null)
                throw new ArgumentNullException("controllerFactory");
            this.innerControllerFactory = controllerFactory;
        }
        private readonly IControllerFactory innerControllerFactory;
		
		// Implement IControllerFactory members and delegate each
		// call to the innerControllerFactory if it doesn't apply here.
	}
