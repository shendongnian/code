    public class ExceptionHandlingAspect : IAspect
    {
        private void Log(Exception exception)
        {
            //...
        }
 
        public IEnumerable<IAdvice> Advise(MethodInfo method)
        {
            //advise only if method is tagged.
            if (Attribute.IsDefined(method, typeof(LoggingCallHandlerAttribute))
            {
                //get attribute
                var attribute = method.GetCustomAttributes(typeof(LoggingCallHandlerAttribue))[0] as LoggingCallHandlerAttribute;
                //describe how yo rewrite method.
                yield return Advice.Basic.Arround(invoke =>
                {
                    try { invoke(); } //call original code
                    catch (Exception e)
                    {
                         if (attribute.Rethrow)
                         {
                             throw;
                         }
                         if (attribute.Log)
                         {
                             this.Log(e);
                         }
                    }
                });
            }
        }
    }
