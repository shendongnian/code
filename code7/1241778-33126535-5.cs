    public class DerivedClass : BaseClass
    {
      // protected
        protected override void SortQuery(ref IQueryable<CouponTableRecord> aQuery, string aSortKey, SortOrder aSortOrder, bool aIsPrimarySort)
        {
          if (aSortKey == SortKeys.ID) // *2
            aQuery = aQuery.Sort(r => r.ID, aSortOrder, aIsPrimarySort); // *3
          else
          if (aSortKey == SortKeys.Caption) 
            aQuery = aQuery.Sort(r => r.Caption, aSortOrder, aIsPrimarySort);
          else
            ...
        }
        
      // private
        private class SortKeys
        {
          public const string ID = "ID";
          public const string Caption = "Caption";
          ...
        }      
    }
