    IEnumerable<Type> TypesImplementingInterface( Type interfaceType , params Type[] desiredConstructorSignature )
    {
      if (  interfaceType == null     ) throw new ArgumentNullException(       "interfaceType" ) ;
      if ( !interfaceType.IsInterface ) throw new ArgumentOutOfRangeException( "interfaceType" ) ;
      
      return AppDomain
             .CurrentDomain
             .GetAssemblies()
             .SelectMany( a => a.GetTypes() )
             .Where( t =>  t.IsAssignableFrom( interfaceType ) )
             .Where( t => !t.IsInterface )
             .Where( t =>  t.GetConstructor( desiredConstructorSignature ) != null )
             ;
    }
