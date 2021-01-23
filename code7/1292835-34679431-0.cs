    StringBuilder query = new StringBuilder();
    query.AppendLine("SELECT [Extent1].[billNum] AS [billNum],");
    query.AppendLine("       [Extent1].[orderSource] AS [orderSource],");
    query.AppendLine("       [Extent1].[sourceOddNum] AS [sourceOddNum],");
    query.AppendLine("       [Extent2].[PPT] AS [PPT]");
    query.AppendLine("FROM [dbo].[New_OrderForm] AS [Extent1]");
    query.AppendLine("INNER JOIN [dbo].[New_OrderGoodsDetail] AS [Extent2] ON [Extent1].[billNum] = [Extent2].[billNum]");
    List<Order> orders = DbContext.Database.SqlQuery<Order>(query.ToString()).ToList();
