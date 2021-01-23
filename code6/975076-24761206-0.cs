    public class YourCustomGenericCloser: IGenericImplementationMatchingStrategy
    {
       public Type[] GetGenericArguments(ComponentModel model, CreationContext context)
       {
          if(context.RequestedType == typeof(IFoo))
          {
             return typeof(TheDefaultTypeToCloseAgainst);
          }
          return null;
       }
    }
