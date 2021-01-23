    public class MyModuleResolver 
    {
        private readonly IUnityContainer container;
        public MyModuleResolver(IUnityContainer container)
        {
            if(container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }
    }
