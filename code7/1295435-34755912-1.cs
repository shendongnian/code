    namespace CustomerAServices.Services
    {
        public class ServiceA : CoreServices.Services.ServiceA
        {
            public override string Test
            {
                get { return "CustomerAServices: ServiceA"; }
            }
        }
    }
