    public class SomeController : ApiController
    {
        private readonly IUnitOfWork _uow;
        public SomeController (IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IHttpActionResult SomeAction() 
        {
            // Get a second UoW
            using (var separatelyScopedResolver = GlobalConfiguration.Configuration.DependencyResolver.BeginScope())
            {
                var anotherUoW = separatelyScopedResolver.GetService(typeof (IUnitOfWork));
                // Do something with this UoW...
                anotherUoW.Save();
            }
           
             // Do something with the default UoW...
             _uow.Save();
             // Et cetera...
        }
    }
