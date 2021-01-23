    public SpaceIdAttribute(Type delegateType, string delegateName)
    {
      var factoryMethod = delegateType.GetMethod(delegateName);
      spaceGetter = (SpaceIdGetter)factoryMethod.Invoke(null, null);
    }
