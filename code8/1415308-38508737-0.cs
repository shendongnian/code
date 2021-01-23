    class Impl : ICov<Dog>
    {
      public void maybe_safe_set(Dog v)
      {
        v.Woof(); // our 'Dog' v can really bark
      }
    }
