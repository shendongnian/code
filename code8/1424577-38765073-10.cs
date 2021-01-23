     abstract class Product : IComparable<Product>
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Barcode { get; set; }
            protected abstract int InternalSortOrder { get; }
            protected virtual string SortBy { get {return Name;} }
    
    
            public int CompareTo(Product obj)
            {
                var sameType = string.Compare(GetType().Name, obj.GetType().Name, StringComparison.Ordinal) == 0;
    
                var sameBaseType = GetType().BaseType != null && obj.GetType().BaseType != null &&
                                   string.Compare(GetType().BaseType.ToString(), obj.GetType().BaseType.ToString(),
                                       StringComparison.Ordinal) == 0;
    
    
                // They have the same base type, but not the same type. Order by base type first.
                if (!sameType && !sameBaseType && GetType().BaseType != null && obj.GetType().BaseType != null)
                {
                    // Order by base type first.
                    return string.Compare(GetType().BaseType.ToString(), obj.GetType().BaseType.ToString(),
                        StringComparison.Ordinal);
                }
    
                // it's the same base type (eg. book or disc)
                if (sameBaseType)
                {
                    // Order by sort order.
                    if (obj.InternalSortOrder != this.InternalSortOrder)
                    {
                        return InternalSortOrder.CompareTo(obj.InternalSortOrder);
                    }
                }
    
                if (sameType)
                {
                    // Same sort order. We sort by name.
                    return string.Compare(SortBy, obj.SortBy, StringComparison.Ordinal);
                }
    
                // Order by Type.
                return string.Compare(GetType().Name, obj.GetType().Name, StringComparison.Ordinal);
            }
    
        }
    
        abstract class Book : Product
        {
            public int PagesCount { get; set; }
        }
    
        class ProgrammingBook : Book
        {
            public string ProgrammingLanguage { get; set; }
    
            protected override int InternalSortOrder
            {
                get { return 1; }
            }
        }
    
        class CulinaryBook : Book
        {
            public string MainIngridient { get; set; }
    
            protected override int InternalSortOrder
            {
                get { return 2; }
            }
        }
    
        class EsotericBook : Book
        {
            public int MininumAge { get; set; }
    
            protected override int InternalSortOrder
            {
                get { return 3; }
            }
        }
        abstract class Disc : Product
        {
            internal enum Content
            {
                Music,
                Video,
                Software
            }
    
            protected override string SortBy
            {
                get { return DiscContent.ToString(); }
            }
    
            public Content DiscContent { get; set; }
        }
    
        class CdDisc : Disc
        {
            protected override int InternalSortOrder
            {
                get { return 1; }
            }
        }
    
        class DvdDisc : Disc
        {
            protected override int InternalSortOrder
            {
                get { return 2; }
            }
        }
