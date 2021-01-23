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
                return string.Compare(Name, obj.Name, StringComparison.Ordinal);
            }
         
            // Order by Type.
            return string.Compare(GetType().Name, obj.GetType().Name, StringComparison.Ordinal);
        }
