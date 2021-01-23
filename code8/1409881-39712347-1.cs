     using System;
     using System.Reflection;
    [module: LogMethod] // Atribute should be "registered" by adding as module or assembly custom attribute
    // Any attribute which provides OnEntry/OnExit/OnException with proper args
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Constructor | AttributeTargets.Assembly | AttributeTargets.Module)]
    public class LogMethodAttribute : Attribute, IMethodDecorator
    {
        private MethodBase _method;
        // instance, method and args can be captured here and stored in attribute instance fields
        // for future usage in OnEntry/OnExit/OnException
        public void Init(object instance, MethodBase method, object[] args)
        {
            _method = method;
        }
        public void OnEntry()
        {
            NLogging.Trace("Entering into {0}", _method.Name);
        }
        public void OnExit()
        {
            NLogging.Trace("Exiting into {0}", _method.Name);
        }
        public void OnException(Exception exception)
        {
            NLogging.Trace(exception, "Exception {0}", _method.Name);
        }
    }
