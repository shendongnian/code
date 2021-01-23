    class FooComparer : IEqualityComparer<Foo>
    {
      private string keyGen(Foo foo)
      {
        return string.Join('|',
          from bar in foo.Bars
          order by bar.Id
          select bar.Id.ToString());
      }
      public bool Equals(Foo left, Foo right)
      {
        if (left == null || right == null) return false;
        return keyGen(left) == keyGen(right);
      }
      public bool GetHashCode(Foo foo)
      {
        return keyGen(foo).GetHashCode();
      }
    }
