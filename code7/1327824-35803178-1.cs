    public MyClass()
    {
          if(SynchronizationContext.Current != null)
          {
             MainUIThread = SynchronizationContext.Current.CreateCopy();
          }
    }
