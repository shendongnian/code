    internal class TableWrapperProvider : Provider<ITableWrapper>
    {
        private readonly ITableProvider _tableProvider;
        public TableWrapperProvider(ITableProvider tableProvider)
        {
            _tableProvider = tableProvider;
        }
        protected override ITableWrapper CreateInstance(IContext context)
        {
            var parameterTarget = context.Request.Target as ParameterTarget;
            if (parameterTarget == null)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "context.Request.Target {0} is not a {1}",
                        context.Request.Target.GetType().Name,
                        typeof(ParameterTarget).Name));
            }
            var tableIdAttribute = parameterTarget.Site.GetCustomAttribute<TableIdAttribute>();
            if (tableIdAttribute == null)
            {
                throw new InvalidOperationException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "ParameterTarget {0}.{1} is missing [{2}]",
                        context.Request.Target,
                        context.Request.Target.Member,
                        typeof(TableIdAttribute).Name));
            }
            return new TableWrapper(_tableProvider.Open(tableIdAttribute.TableName));
        }
    }
