    private IQueryable<Part> GetParts_Base()
    {
        //Proprietary. Replace with your own.
        var context = ContextManager.GetDbContext();
    
        var query = from c in context.Component
                    where c.Active
                    //kind of pointless to select into a new object without a join, but w/e
                    select new Part()
                    {
                        PartNumber = c.ComponentNumber,
                        Description = c.ComponentDescription,
                        Cost = c.ComponentCost,
                        Price = c.ComponentPrice
                    };
    
        return query;
    }
    
    //Exclude cost from this view
    public IEnumerable<Part_PublicView> GetParts_PublicView(decimal maxPrice)
    {
        var query = GetParts_Base();
    
        var results = from p in query
                      where p.Cost < maxPrice
                      select new Part_PublicView()
                      {
                          PartNumber = p.PartNumber,
                          Description = p.Description,
                          Price = p.Price
                      };
    
        return results;
    }
    
    public class Part_PublicView
    {
        public string PartNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    
    private class Part : Part_PublicView
    {
        public decimal Cost { get; set; }
    }
