      class CustomPictureInterceptor : NHibernate.Proxy.DynamicProxy.IInterceptor
        {
            public object Intercept(InvocationInfo info)
            {
                //Do what you want
                return info.InvokeMethodOnTarget();
            }
        }
