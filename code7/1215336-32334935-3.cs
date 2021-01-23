    public static void ProcessAll<T>
      (this BlockingCollection<SignalizableItem<T>> @this, Action<T> action, 
       CancellationToken cancellationToken)
    {
      SignalizableItem<T> val;
      while (@this.TryTake(out val, -1, cancellationToken)) val.Process(action);
    }
