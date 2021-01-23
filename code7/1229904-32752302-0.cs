    public class MyFilter 
    {
       public int? ById { get; set; }
       public string ByName { get; set; }
       /// etc...
    }
    IQuerayble<Asset> GetAssets(MyFilter filter) 
    {
        IQueryable<Asset> query = model.Assets; 
        if (filter.ById.HasValue)
            query = query.Where(a => a.Id == filter.ById.Value);
        if (!string.IsNullOrWhitespace(filter.ByName))
            query = query.Where(a => a.Id == filter.ByName);
        query = query.Select(... // your select code here);
        return query;
    }
