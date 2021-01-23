    //Http Parameter Binding Magic
    public class ObjectIdParameterBinding : HttpParameterBinding
    {
        public ObjectIdParameterBinding(HttpParameterDescriptor p) : base(p){ }
        public override Task ExecuteBindingAsync(System.Web.Http.Metadata.ModelMetadataProvider metadataProvider, HttpActionContext actionContext, System.Threading.CancellationToken cancellationToken)
        {
            var value = actionContext.ControllerContext.RouteData.Values[Descriptor.ParameterName].ToString();
            SetValue(actionContext, ObjectId.Parse(value));
            var tsc = new TaskCompletionSource<object>();
            tsc.SetResult(null);
            return tsc.Task;
        }
    }
    //Binding Attribute
    public class ObjectIdRouteBinderAttribute : ParameterBindingAttribute
    {
        public override HttpParameterBinding GetBinding(HttpParameterDescriptor parameter)
        {
            return new ObjectIdParameterBinding(parameter);
        }
    }
    //Controller Example
    [Route("api/users/{id}")]
    public async Task<User> Get([ObjectIdRouteBinder] ObjectId id) 
    {
        //Yay!
    }
