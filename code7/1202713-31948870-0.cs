        // Summary:
        //     Creates a subset of this collection of objects that can be individually accessed
        //     by index and containing metadata about the collection of objects the subset
        //     was created from.
        //
        // Parameters:
        //   superset:
        //     The collection of objects to be divided into subsets. If the collection implements
        //     System.Linq.IQueryable<T>, it will be treated as such.
        //
        //   pageNumber:
        //     The one-based index of the subset of objects to be contained by this instance.
        //
        //   pageSize:
        //     The maximum size of any individual subset.
        //
        // Type parameters:
        //   T:
        //     The type of object the collection should contain.
        //
        // Returns:
        //     A subset of this collection of objects that can be individually accessed
        //     by index and containing metadata about the collection of objects the subset
        //     was created from.
    public static IPagedList<T> ToPagedList<T>(this IQueryable<T> superset, int pageNumber, int pageSize);
