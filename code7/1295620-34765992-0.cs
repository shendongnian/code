    public static BindTable(IKernel kernel, ITableProvider tableProvider, string tableName)
    {
        kernel.Bind<ITableWrapper>()
              .ToMethod(ctx => new tableWrapper(tableProvider.OpenTable(tableName))
              .Named(tableName);
    }
