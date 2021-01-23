    // Initialize AutoMapper
    Mapper.Initialize(cfg => 
    { 
        cfg.CreateMap<TE, TD>();
        cfg.CreateMap<TD, TE>();
    });
    public class Repo
    {
        // Wrap Func with Expression
        public IEnumerable<TD> Get(Expression<Func<IQueryable<TD>, IOrderedQueryable<TD>>> orderBy = null)
        {
            var orderByExpr = Mapper.Map<Expression<Func<IQueryable<TE>, IOrderedQueryable<TE>>>>(orderBy);            
            IQueryable<TE> query = CurrentDbSet;
            // Compile expression and execute as function 
            var items = orderByExpr.Compile()(query).ToList();
            // Map back to list of TD
            return Mapper.Map<IEnumerable<TD>>(items);
        }
    }
