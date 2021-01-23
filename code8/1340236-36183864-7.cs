    public class CommunicationService
    {
        IContext context;
    
        public CommunicationService()
        {
            var kernel = new StandardKernel(new NinjectConfig());
            context = kernel.Get<IContext>();
        }
