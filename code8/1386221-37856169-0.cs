    class DummyActionDescriptor : HttpActionDescriptor {
        public DummyActionDescriptor(Type messageType, Type returnType) {
            this.ControllerDescriptor = new DummyControllerDescriptor() {
                ControllerName = "Message Handlers"
            };
            this.ActionName = messageType.Name;
            this.ReturnType = returnType;
        }
        public override Collection<HttpParameterDescriptor> GetParameters() {
            // note you might provide properties of your message class and HttpParameterDescriptor here
            return new Collection<HttpParameterDescriptor>();
        }
       public override string ActionName { get; }
       public override Type ReturnType { get; }
        public override Task<object> ExecuteAsync(HttpControllerContext controllerContext, IDictionary<string, object> arguments, CancellationToken cancellationToken) {
            // will never be called by swagger
            throw new NotSupportedException();
        }
    }
    class DummyControllerDescriptor : HttpControllerDescriptor {
        public override Collection<T> GetCustomAttributes<T>() {
             // note you might provide some asp.net attributes here
            return new Collection<T>();
        }
    }
