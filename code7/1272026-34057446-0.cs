    // Somewhere in .cs file
    public List<Expression<Func<MyModel, object>>> GetListToDisplay()
    {
      var list = new List<Expression<Func<MyModel, object>>>();
  
      list.Add(x => x.myProperty1);
      list.Add(x => x.myProperty2);
      list.Add(x => x.myMethod());
      return list;
    }
    
    // In your View
    @model MyModel  
    foreach (var expr in GetListToDisplay())
    {
        @Html.DisplayNameFor(expr)
    }
