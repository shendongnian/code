    public class BaseClass
    {
      // public
        public void DoSomething()
        {
          System.Linq.IQueryable<TRecord> lQuery = ...
          System.Collections.Generic.Dictionary<string, SortOrder> lSorting = ...
          
          ...
          SortQuery(lQuery, lSorting);
          ...
        }
    
      // protected
        protected abstract void SortQuery(ref System.Linq.IQueryable<TRecord> aQuery, string aSortKey, SortOrder aSortOrder, bool aIsPrimarySort);
        
      // private
        private void SortQuery(ref System.Linq.IQueryable<TRecord> aQuery, System.Collections.Generic.Dictionary<string, SortOrder> aSorting)
        {
          bool lIsPrimarySort = true;
          foreach (string lSortKey in aSorting.Keys)
          {
            SortQuery(ref aQuery, lSortKey, aSorting[lSortKey], lIsPrimarySort);
            lIsPrimarySort = false;
          }
        }
    }
      
