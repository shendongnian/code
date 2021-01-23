    public class SorterBase<TEntity>
    {                                                               
        public abstract IEnumerable<TEntity> GetSorted( // Note, no order argument here
            int skip, int take, 
            params Expression<Func<TEntity, object>>[] includes);
    }
     
    public class Sorter<TEntity, TSortProp> : SorterBase<TEntity>
    {                                                               
        private Expression<Func<TEntity, TSortProp>> _order;
        
        public Sorter(Expression<Func<TEntity, TSortProp>> order)
        {
            _order = order;
        }
        
        public override IEnumerable<TEntity> GetSorted(...)
        {
           // Use _order here ...
        }
    }
