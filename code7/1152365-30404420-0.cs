    class Update<TField>
    {
      public Expression<Func<MyType, TField>> MemberExpression { get; set; }
      public TField NewValue { get; set; }
    }
