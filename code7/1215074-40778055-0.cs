        private void Log(Exception exception)
        {
            //...
        }
 
        override protected Advice Advise(Type type, MethodInfo method)
        {
            //advise only if method is tagged.
            if (Attribute.IsDefined(method, typeof(LoggingCallHandlerAttribute))
            {
                //get attribute
                var attribute = method.GetCustomAttributes(typeof(LoggingCallHandlerAttribue))[0] as LoggingCallHandlerAttribute;
                //describe how yo rewrite method.
                return new Arround(invoke =>
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
            return null; //no advice = method unchanged
        }
    }
