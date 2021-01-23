    // A struct instead of a sealed class. This means instead of
    // null we have the implicit empty constructor. The empty
    // constructor initializes all fields to their default values
    // which is determined by their type.
    //
    // The trick here is that default(Maybe<A>) = Maybe<A>.Nothing().
    //
    public struct Maybe<A>
    {
      // Same as before.
      private enum Tag : byte
      {
        // Must be 0, because this is the default value of any enum.
        Nothing = 0,
        Just = 1
      }
    
      // By default is Nothing
      private readonly Tag TheTag;
    
      // Can use type A instead of object. Saves a cast.
      private readonly A Value;
    
      // Same as before.
      private Maybe(Tag theTag, A value)
      {
        TheTag = theTag;
        Value = value;
      }
    
      // Same as before.
      public B Cases<B>(Func<B> caseNothing, Func<A,B> caseJust)
      {
        switch (TheTag)
        {
          case Nothing: return caseNothing();
          case Just: return caseJust(Term);
          default: throw new Exception("missing case!");
        }
      }
    
      // Same as before.
      public static Maybe<A> Nothing()
      {
        return new Maybe<A>(Tag.Nothing, default(A));
      }
    
      // Same as before.
      public static Maybe<A> Just(A value)
      {
        return new Maybe<A>(Tag.Just, value);
      }
    
    }
