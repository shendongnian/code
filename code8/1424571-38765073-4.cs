    abstract class Product : IComparable<Product> 
    {
        // Other....
        public string Name { get; set; }
        protected abstract int InternalSortOrder { get; } // For breaking ties.
        public int CompareTo(Product obj)
        {
            // If it's the same type. Eg. CdDisc.
            var sameType = string.Compare(GetType().Name, obj.GetType().Name, StringComparison.Ordinal) == 0;
            // If it's the same base type. Eg Book or Disc.
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
                // Order by sort order. This way CD will apppear before DVD.
                if (obj.InternalSortOrder != this.InternalSortOrder)
                {
                    return InternalSortOrder.CompareTo(obj.InternalSortOrder);
                }
            }
            if (sameType)
            {
                // Same sort order. We sort by name.
                return string.Compare(Name, obj.Name, StringComparison.Ordinal);
            }
         
            // Order by Type.
            return string.Compare(GetType().Name, obj.GetType().Name, StringComparison.Ordinal);
        }
    }
