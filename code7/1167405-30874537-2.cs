    public interface IPagedEntities<out T>
    {
        int Page { get; }
        int PageSize { get; }
        int TotalSize { get; }
        int Pages { get; }
        int NumberSkipped { get; }
        int? NextPage { get; }
        int? PriorPage { get; }
        int FirstPage { get; }
        int LastPage { get; }
        bool OnFirstPage { get; }
        bool OnLastPage { get; }
        bool HasNextPage { get; }
        bool HasPreviousPage { get; }
    
        IEnumerable<T> Entities { get; }
    }
