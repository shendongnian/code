    public class MyDomainService
    {
        public bool IsPrintable(IList<Items> items, IList<Pages> pages)
        {
            return ...;
        }
    }
    ...
    model.IsPrintable = domainSvc.IsPrintable(items, pages);
