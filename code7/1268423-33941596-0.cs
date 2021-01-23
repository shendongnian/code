    public class LoggingPipelineModule : HubPipelineModule 
    { 
        protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context) 
        {
            Debug.WriteLine("Invoking '{0}.{1}({2})'.",
                context.MethodDescriptor.Hub.Name,
                context.MethodDescriptor.Name,
                string.Join(", ", context.Args));
            return base.OnBeforeIncoming(context); 
        }
    }
