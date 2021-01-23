    public class Subscription
    {
      public readonly MethodInfo MethodInfo;
      public readonly WeakReference TargetObjet;
    
      public Subscription(Action<Tmessage> action, EventAggregator eventAggregator)
      {
          MethodInfo = action.Method;
          TargetObjet = new WeakReference(action.Target);
      }
    }
