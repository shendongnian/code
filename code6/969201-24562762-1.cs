    T ConstructInstance<T>( Type t , object[] parameterList )
    {
      Type[]          signature   = parameterList
                                    .Select( p => p.GetType() )
                                    .ToArray()
                                    ;
      ConstructorInfo constructor = t.GetConstructor(   signature     ) ;
      T               instance    = constructor.Invoke( parameterList ) ;
      return instance ;
    }
