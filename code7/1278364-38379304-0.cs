    public IActionResult GetTableData(string requestedContext, string requestedTable)
    {
        var context = GetContext(requestedContext);
    
        if (context == null)
        {
            return new ErrorObjectResult("Invalid context specified");
        }
        var entity = context.GetEntity(requestedTable);
    
        if (entity == null)
        {
            return new ErrorObjectResult("Invalid table specified");
        }
    
        var boundMethod = s_getTableDataMethodInfo.MakeGenericMethod(entity.ClrType);
        return boundMethod.Invoke(this, new object[] { context }) as IActionResult;
    }
    
    private static readonly MethodInfo s_getTableDataMethodInfo
        = typeof(MyController).GetTypeInfo().GetDeclaredMethod("GetTableDataForEntity");
    
    private IActionResult GetTableDataForEntity<TEntity>(DbContext context)
        where TEntity : class
    {
        var data = Request.Query;
        var start = Convert.ToInt32(data["start"].ToString());
        var count = Convert.ToInt32(data["length"].ToString());
        var search = data["search[value]"];
    
        return new ObjectResult(context.Set<TEntity>().Skip(start).Take(count));
    }
