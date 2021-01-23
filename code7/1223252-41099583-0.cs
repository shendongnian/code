    public class SpringNetActivator: JobActivator
    {
        private readonly IApplicationContext _springContext;
        public SpringNetActivator(IApplicationContext springContext)
        {
            _springContext = springContext;
        }
        public override object ActivateJob(Type jobType)
        {
            return _springContext.GetObject(jobType.Name);
        }
        public override JobActivatorScope BeginScope(JobActivatorContext context)
        {
            //some code here
            return base.BeginScope(context);
        }
    }
