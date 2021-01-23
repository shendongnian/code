    public class GenericContractBinding : HttpParameterBinding
    {
       public GenericContractBinding(HttpParameterDescriptor descriptor) : base(descriptor){}
       public override Task ExecuteBindingAsync(ModelMetadataProvider provider, HttpActionContext context, CancellationToken cancellationToken)
       {
          if(context.ControllerContext.Configuration.DependencyResolver != null)
          {
             //This is a naive eval based only on the incoming type. You'll likely want to map
             var bazinga = context.Request.GetDependencyScope().GetService(Descriptor.ParameterType);
             if(bazinga.GetType() == typeof(GenericContract)
                context.ActionArguments[Descriptor.ParameterName] = bazinga;
          }
       }
    }
