    public class TableNameParameter : Parameter
    {
        public override Boolean CanSupplyValue(
            ParameterInfo pi, IComponentContext context, out Func<Object> valueProvider)
        {
            valueProvider = null;
            if (pi.ParameterType != typeof(String) && pi.Name != "tableName")
                return false;
            valueProvider = () =>
            {
                ITableNameResolver tableNameResolver = context.Resolve<ITableNameResolver>();
                Type entityType = pi.Member.DeclaringType.GetGenericArguments()[0];
                String tableName = tableNameResolver.GetTableName(entityType);
                return tableName;
            };
            return true;
        }
    }
