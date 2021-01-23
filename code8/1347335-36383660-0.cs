    // Sealed because we don't want subtypes of our ADT.
    public sealed class Example<A>
    {
      // A class for each constructor.
      // Sealed because we cannot allow subtypes to be defined and used.
      public sealed class Foo
      {
        public readonly A foo;
        public Foo(A foo) { this.foo = foo; }
      }
    
      // A class for each constructor.
      // Sealed because we cannot allow subtypes to be defined and used.
      public sealed class Bar
      {
        public readonly A bar;
        public readonly int qux;
        public Bar(A bar, int qux) { this.bar = bar; this.qux = qux; }
      }
    
      // An enum of constructors.
      // Private because this is an implementation detail.
      private enum Tag : byte
      {
        Foo,
        Bar
      }
    
      // Store the constructor used.
      // Private because this is an implementation detail.
      private readonly Tag TheTag;
    
      // Store the term object.
      // Private because we will define safe case analysis to access
      // this value later.
      private readonly object Term;
    
      // The only constructor.
      // Private because we are going to define proper ways to
      // construct Example`1 later.
      private Example(Tag tag, object term)
      {
        TheTag = tag;
        Term = term;
      }
    
      // Case analysis. This is how you get the value back out.
      // This is like case/of or the functions "maybe", "either", etc.
      public B Cases<B>(Func<Foo,B> caseFoo, Func<Bar,B> caseBar)
      {
        // Because we defined an enum we can use an efficient switch
        // statement to jump directly to the correct branch.
        switch (TheTag)
        {
          // These casts are guaranteed to be safe because of the
          // functions we define to construct Example`1's.
          case Tag.Foo: return caseFoo((Foo)Term);
          case Tag.Bar: return caseBar((Bar)Term);
          // C# does not check the exhaustiveness of the switch statement
          // so we have to throw something here unfortunately.
          default: throw new Exception("missing case!");
        }
      }
    
      // This constructs an Example`1 with the Foo constructor.
      public static Example<A> Create(Foo term)
      {
        return new Example<A>(Tag.Foo, term);
      }
    
      // This constructs an Example`1 with the Bar constructor.
      public static Example<A> Create(Bar term)
      {
        return new Example<A>(Tag.Bar, term);
      }
    
      // You can define whatever other conveniences you want!
    }
