    static bool CheckForEquality(object a, object b)
    {
        // Here we handle default and custom comparison assuming
        // types are "well-formed" and with good habits.
        if (a.Equals(b))
            return true; // Should also check hashcode?
        var comparableA = a as IComparable;
        if (comparableA != null)
            return comparableA.CompareTo(b) == 0;
        // Different instances and one of them is null, they're different unless
        // it's a special case handled by "a" object (with IComparable).
        if (Object.ReferenceEquals(b, null))
            return false;
        // In case "b" has a custom comparison for objects of type "a"
        // but not vice-versa.
        if (b.Equals(a))
            return true;  // Should also check hashcode?
        // We assume we can compare only the same type. It's not true
        // because of custom comparison operators but it should also be
        // handled in Object.Equals().
        var type = a.GetType();
        if (type != b.GetType())
            return false;
        // Special case for lists, they won't match but we may consider
        // them equal if they have same elements and each element match
        // corresponding one in the other object.
        // This comparison is order sensitive so A,B,C != C,B,A.
        // Items must be first ordered if this isn't what you want.
        // Also note that a better implementation should check for
        // ICollection as a special case and IEnumerable should be used.
        // An even better implementation should also check for
        // IStructuralComparable and IStructuralEquatable implementations.
        var listA = a as System.Collections.ICollection;
        if (listA != null)
        {
            var listB = b as System.Collections.ICollection;
            if (listA.Count != listB.Count)
                return false;
            var aEnumerator = listA.GetEnumerator();
            var bEnumerator = listB.GetEnumerator();
            while (aEnumerator.MoveNext() && bEnumerator.MoveNext())
            {
				if (!CheckForEquality(aEnumerator.Current, bEnumerator.Current))
                    return false;
            }
            // We don't return true here, a class may implement IList and also have
            // many other properties, go on with our comparison
        }
        // If we arrived here we have to perform a property by
        // property comparison recursively calling this function.
        // Note that here we check for "public interface" equality.
        var properties = type.GetProperties().Where(x => x.GetMethod != null);
        foreach (var property in properties)
        {
			if (!CheckForEquality(property.GetValue(a), property.GetValue(b)))
                return false;
        }
        // If we arrived here then objects can be considered equal
        return true;
    }
