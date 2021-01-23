    public class MyControllerFactory : DefaultControllerFactory
    {
        private readonly MyReader _reader;
        public MyControllerFactory (MyReader reader)
        {
            _reader = reader;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, "Controller not found.");
            }
            // Change the line below to whatever suits your needs.
            return _reader.CreateController(new MyImplementation());
        }
        public override void ReleaseController(IController controller)
        {
            // You may have a way to destroy a controller as well.
        }
    }
