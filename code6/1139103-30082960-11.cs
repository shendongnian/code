    public class PrepareNancyContextWrapper : IRequestStartup
    {
        private readonly INancyContextWrapper _nancyContext;
        public PrepareNancyContextWrapper(INancyContextWrapper nancyContext)
        {
            _nancyContext = nancyContext;
        }
    
        public void Initialize(IPipelines piepeLinse, NancyContext context)
        {
             _nancyContext.Context = context;
        }
    }
