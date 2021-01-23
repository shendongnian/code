    void Test<T>(Expression<Func<T>> func)
    {
      var body = func.Body;
      if (body.NodeType == ExpressionType.Constant)
      {
        Console.WriteLine(((ConstantExpression)body).Value);
      }
      else
      {
        var memberExpression = (MemberExpression)body;
        var @object = 
          ((ConstantExpression)(memberExpression.Expression)).Value; //HERE!
        if (memberExpression.Member.MemberType == MemberTypes.Field)
        {
          Console.WriteLine(((FieldInfo)memberExpression.Member).GetValue(@object));
        }
        else if (memberExpression.Member.MemberType == MemberTypes.Property)
        {
          Console.WriteLine(((PropertyInfo)memberExpression.Member).GetValue(@object));
        }
      }
    }
