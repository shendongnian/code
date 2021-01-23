    //Gets whether the list supports sorting.
    bool SupportsSorting { get; }
    //Gets whether the items in the list are sorted.
    bool IsSorted { get; }
    //Gets the PropertyDescriptor that is being used for sorting.
    PropertyDescriptor SortProperty { get; } 
    //Gets the direction of the sort.
    ListSortDirection SortDirection { get; } 
    //Sorts the list based on a PropertyDescriptor and a ListSortDirection.
    void ApplySort( PropertyDescriptor property, ListSortDirection direction);
    //Removes any sort applied using ApplySort.
    void RemoveSort(); 
