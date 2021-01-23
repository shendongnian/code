    public class InterceptionFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.ComponentRegistered += new Castle.MicroKernel.ComponentDataDelegate(Kernel_ComponentRegistration);
        }
        void Kernel_ComponentRegistration(string key, Castle.MicroKernel.IHandler handler)
        {
            if (typeof(IEventuallyRegistered).IsAssignableFrom(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(EventuallyRegisteredInterceptor)));
            }
        }
    }
