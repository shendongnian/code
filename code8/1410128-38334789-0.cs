    [__DynamicallyInvokable]
    public KeyedCollection<System.Type, IEndpointBehavior> EndpointBehaviors
    {
      [__DynamicallyInvokable] get
      {
        return (KeyedCollection<System.Type, IEndpointBehavior>) this.Behaviors;
      }
    }
