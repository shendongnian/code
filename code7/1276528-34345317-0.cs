        public class ExceptionHandlingControllerActivator : IHttpControllerActivator
        {
            private readonly IHttpControllerActivator _concreteActivator;
            public ExceptionHandlingControllerActivator(IHttpControllerActivator concreteActivator)
            {
                _concreteActivator = concreteActivator;
            }
            public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
            {
                try
                {
                    return _concreteActivator.Create(request, controllerDescriptor, controllerType);
                }
                catch (Exception ex)
                {
                    // do stuff with the exception
                    throw new HttpResponseException(request.CreateResponse(HttpStatusCode.InternalServerError, new ResponseModel(ex)));
                }
            }
        }
