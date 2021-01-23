    public static class Metadata<TType> {
      public static string TableName() {
        var type = typeof(TType);
        var attrib = type.GetCustomAttribute<TableAttribute>(false);
        return attrib?.Name ?? type.Name;
      }
      public static string ColumnName<TMember>(Expression<Func<TType, TMember>> propertyExpresseion) {
        if (propertyExpresseion.Body.NodeType != ExpressionType.MemberAccess) {
          throw new InvalidOperationException();
        }
        var member = propertyExpresseion.Body as MemberExpression;
        var property = member.Member;
        var attrib = property.GetCustomAttribute<ColumnAttribute>(false);
        return attrib?.Name ?? property.Name;
      }
    }
